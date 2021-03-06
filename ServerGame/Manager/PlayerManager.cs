﻿using ServerBase.Dispatch;
using ServerBase.GameObject;
using ServerBase.Protocol;
using SuperSocket.SocketLuanr;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ServerGame.Manager
{
    public static class PlayerManager
    {
        //public static Dictionary<long, CLS_PlayerXY> m_DictPlayerXY = new Dictionary<long, CLS_PlayerXY>();
        public static Dictionary<long, Player> DictPlayerOnline = new Dictionary<long, Player>();

        
        /// <summary>
        /// 初始化
        /// </summary>
        public static void Init()
        {
            BaseDispatch.BindEventHandler(OnPlayerXY, EProtocolId.E2G_GAME_PLAYERXY);
            BaseDispatch.BindEventHandler(OnLogin, EProtocolId.L2E_GAME_LOGINSERVER);
            BaseDispatch.BindEventHandler(OnRegister, EProtocolId.L2E_GAME_REGISTER);
            BaseDispatch.BindEventHandler(OnLoginOut, EProtocolId.E2G_GAME_LOGINOUT);
            //BaseDispatch.BindEventHandler(OnPlayerMapIn, EProtocolId.E2G_GAME_MAPIN);
        }

        //private static bool isMove = false;
        public static void OnPlayerXY(LunarSession session, LunarRequestInfo requestInfo)
        {            
            var Req = new E2G_Game_PlayerXY(requestInfo.Body);
            DictPlayerOnline.TryGetValue(Req.Puid,out var player);
            Req.PlayerXY.Uid = player.XY.Uid;
            player.XY = Req.PlayerXY;

            var rsp = new G2E_Game_PlayerXYOther();
            rsp.PlayerXY = Req.PlayerXY;
            SendAll(session, rsp, player.Id);

            var rspself = new G2E_Game_PlayerXY();            
            rspself.PlayerXY = Req.PlayerXY;
            rspself.Puid = Req.Puid;

            session.Send(rspself);            
        }

        internal static void Heartbeat()
        {            
            foreach (var player in DictPlayerOnline.Values)
            {
                //if (!m_DictPlayerXY.ContainsKey(player.Id))
                //{
                //    m_DictPlayerXY[player.Id] = new CLS_PlayerXY() { Uid = player.Id };
                //}
            }
            //if (isMove && m_DictPlayerXY.Count > 0)
            //{
            //    var rsp = new G2E_Game_PlayerXY();
            //    rsp.ListPlayerXY = m_DictPlayerXY.Values.ToList();
            //    BaseDispatch.SendAll(rsp);
            //    isMove = false;
            //}                    
        }

        internal static void OnLoginOut(LunarSession session, LunarRequestInfo requestInfo)
        {
            var Req = new E2G_Game_LoginOut(requestInfo.Body);
            DictPlayerOnline.Remove(Req.Puid);
                   
                     
            foreach (var item in DictPlayerOnline.Values)
            {
                if (item.Id == Req.Puid)
                {
                    continue;
                }
                var rsp = new G2E_Game_LoginOut();
                rsp.Puid = item.Id;
                session.Send(rsp);
            }
        }

        internal static void OnLogin(LunarSession session, LunarRequestInfo requestInfo)
        {
            var Req = new L2E_Game_LoginServer(requestInfo.Body);

            var player = new Player(Req.Puid);
            if (!player.Load())
            {
                
            }
            player.XY.Uid = player.Id;

            DictPlayerOnline[Req.Puid] = player;  
            
            var rsp = new G2E_Game_MapIn();
            rsp.PlayerXY = player.XY;
            SendAll(session, rsp, player.Id);            

            var rsp2 = new G2E_Game_MapInOther();            
            foreach (var item in DictPlayerOnline.Values)
            {
                if (item.Id == player.Id)
                {
                    continue;
                }
                item.XY.Uid = item.Id;
                rsp2.ListPlayerXY.Add(item.XY);
                //rsp.Shuttle = Req.Shuttle;                
            }
            rsp2.Puid = player.Id;
            session.Send(rsp2);
        }

        internal static void OnRegister(LunarSession session, LunarRequestInfo requestInfo)
        {
            
        }

        public static void SendAll(LunarSession session, INbsSerializer objMsg,long selfid = 0)
        {
            foreach (var item in DictPlayerOnline.Values)
            {
                if (item.Id == selfid)
                {
                    continue;
                }
                ((ProtocolMsgBase)objMsg).RspPuids.Add(item.Id);
            }
            ((ProtocolMsgBase)objMsg).Puid = selfid;
            if (((ProtocolMsgBase)objMsg).RspPuids.Count > 0 || ((ProtocolMsgBase)objMsg).Puid != 0)
            { session.SendMerge(objMsg); }
        }
    }
}
