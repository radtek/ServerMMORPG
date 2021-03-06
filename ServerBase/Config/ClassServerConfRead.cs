using System.Collections.Generic;
using UtilLib;

namespace ServerBase.Config
{
	public static partial class Conf
	{
		public static bool InitConfSettings()
		{
			bool result = true;

			//服务器列表
			if (result) { result = ReadConfig(typeof(SysServerList).Name, ref SysServerList); }
			//GlobalConfig
			if (result) { result = ReadConfig(typeof(GlobalConfig).Name, ref GlobalConf); }

			if (result) { result = InitConfSettingsExt(); }

			return result;
		}
	}
}
