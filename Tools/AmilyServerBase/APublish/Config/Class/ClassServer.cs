using System.Collections.Generic;

namespace ServerBase.Config
{
	public class ConfigLanguage : IConfigBase	//文件:B_本地化配置表
	{
		public string Id; //ID
		public string Ch; //中文
		public string En; //英文
		public object GetKey() { return Id; }
	}
	public class ConfigBag : IConfigBase	//文件:B_背包
	{
		public int Id; //ID
		public string Name; //名
		public string Desc; //描述
		public int TypeBag; //类别
		public object GetKey() { return Id; }
	}
	public class ConfigDrop : IConfigBase	//文件:D_掉落
	{
		public int Id; //ID
		public int DropType; //掉落类型
		public Dictionary<int, int> Num = new Dictionary<int, int>(); //掉落数量
		public List<List<int>> DropPoll; //掉落池
		public object GetKey() { return Id; }
	}
	public class ConfigDropLimit : IConfigBase	//文件:D_掉落
	{
		public int Id; //ID
		public string AwardType; //类型
		public string Type; //具体ID
		public string DropLimitTime; //掉落限制时间
		public int DropLimit; //掉落数量限制
		public object GetKey() { return Id; }
	}
	public class GlobalConfig : IConfigBase	//文件:Q_全局常数
	{
		public int Id; //ID
		public string Name; //全局名
		public string Desc; //配置说明
		public string Value; //配置值
		public object GetKey() { return Id; }
	}
	public class ConfigExp : IConfigBase	//文件:T_通用
	{
		public int Id; //ID
		public int BreakLevel; //突破等级
		public int Level; //等级
		public List<List<int>> ExpCost; //经验消耗
		public int PowerGrow; //战力成长
		public object GetKey() { return Id; }
	}
	public class ConfigBreak : IConfigBase	//文件:T_通用
	{
		public int Id; //ID
		public int BreakPower; //突破战力
		public int LevelMax; //最大等级
		public int AfterLevel; //突破后等级
		public List<List<int>> ItemCost; //消耗
		public object GetKey() { return Id; }
	}
	public class ConfigForge : IConfigBase	//文件:T_通用
	{
		public int Id; //ID
		public List<List<int>> ItemCost; //消耗
		public int PowerPer; //战力百分比
		public object GetKey() { return Id; }
	}
	public class ConfigReforgeCost : IConfigBase	//文件:T_通用
	{
		public int Id; //ID
		public int LevelNeed; //要求铸造等级
		public List<List<int>> ItemCost; //道具消耗
		public object GetKey() { return Id; }
	}
	public class ConfigStarCost : IConfigBase	//文件:T_通用
	{
		public int Id; //ID
		public int Quality; //品质
		public int StarLevel; //星级
		public List<List<int>> ItemCost; //消耗
		public List<List<int>> Decomposed; //分解获得精华
		public object GetKey() { return Id; }
	}
	public class ConfigResultCode : IConfigBase	//文件:F_返回码
	{
		public int Id; //ID
		public string Default; //默认语言
		public string Ch; //中文
		public string En; //英文
		public object GetKey() { return Id; }
	}
	public class ConfigSurname : IConfigBase	//文件:X_姓名表
	{
		public string Id; //ID
		public object GetKey() { return Id; }
	}
	public class ConfigMalename : IConfigBase	//文件:X_姓名表
	{
		public string Id; //ID
		public object GetKey() { return Id; }
	}
	public class ConfigFemalename : IConfigBase	//文件:X_姓名表
	{
		public string Id; //ID
		public object GetKey() { return Id; }
	}
	public class ConfigBadwords : IConfigBase	//文件:X_姓名表
	{
		public string Id; //ID
		public object GetKey() { return Id; }
	}
	public class ConfigHero : IConfigBase	//文件:Y_英雄
	{
		public int Id; //ID
		public string Name; //名字
		public string Des; //描述
		public string Head; //头像
		public string Resource; //资源
		public int HeroSeries; //归属
		public int Quality; //品质
		public int Race; //种族
		public int Sex; //性别
		public int Profession; //职业
		public int BasisPower; //基础战力
		public float BreakRatio; //突破系数
		public float GrowRatio; //成长系数
		public List<int> GroupSkill = new List<int>(); //技能列表
		public int Limit; //上阵数量限制
		public int ReturnCost; //合成消耗
		public int Star1Skill; //1星技能
		public List<int> Star1Ability = new List<int>(); //1星属性
		public int Star2Skill; //2星技能
		public List<int> Star2Ability = new List<int>(); //2星属性
		public int Star3Skill; //3星技能
		public List<int> Star3Ability = new List<int>(); //3星属性
		public int Star4Skill; //4星技能
		public List<int> Star4Ability = new List<int>(); //4星属性
		public int Star5Skill; //5星技能
		public List<int> Star5Ability = new List<int>(); //5星属性
		public int Star6Skill; //6星技能
		public List<int> Star6Ability = new List<int>(); //6星属性
		public List<int> Level1Ability = new List<int>(); //宝具1阶属性
		public List<int> Level2Ability = new List<int>(); //宝具2阶属性
		public List<int> Level3Ability = new List<int>(); //宝具3阶属性
		public List<int> Level4Ability = new List<int>(); //宝具4阶属性
		public List<int> Level5Ability = new List<int>(); //宝具5阶属性
		public List<int> Level6Ability = new List<int>(); //宝具6阶属性
		public List<int> Level7Ability = new List<int>(); //宝具7阶属性
		public List<int> Level8Ability = new List<int>(); //宝具8阶属性
		public List<int> Level9Ability = new List<int>(); //宝具9阶属性
		public object GetKey() { return Id; }
	}
	public enum EServerType
	{
		客户端 = 0,
		中心 = 1,
		世界 = 2,
		社交 = 3,
		平台 = 4,
		登陆 = 10,
		游戏 = 20,
		战斗 = 30,
		HTTP = 31,
		后台工具 = 100,
	}
	public enum EAccess
	{
		本机调试 = 0,
		内网版本 = 1,
		外网版本 = 2,
	}
	public enum EAwardType
	{
		经验 = 1,
		银两 = 2,
		元宝 = 3,
		木材 = 4,
		食物 = 5,
		铁矿 = 6,
		道具 = 7,
		武将 = 10,
		VIP经验 = 11,
	}
	public enum EDropType
	{
		固定掉落 = 0,
		独立掉落 = 1,
		抽取放回 = 2,
		抽取不放回 = 3,
	}
	public enum EGlobalId
	{
		账号长度最小 = 1,
		账号长度最大 = 2,
		密码长度最小 = 3,
		密码长度最大 = 4,
		昵称长度最小 = 5,
		昵称长度最大 = 6,
		默认英雄列表 = 8,
		最大突破等级 = 10,
		最大星级 = 11,
		最大重铸等级 = 12,
		防御系数 = 14,
		闪避系数 = 15,
		王者系数 = 16,
		普攻系数1 = 17,
		普攻系数2 = 18,
		先攻增加暴击伤害系数 = 19,
		闪避增加恢复效果系数 = 20,
		最小伤害值 = 21,
		抽卡积分上限 = 23,
		抽卡积分赠送道具 = 24,
	}
}
