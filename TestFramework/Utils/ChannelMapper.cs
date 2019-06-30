using System.Collections.Generic;

namespace TestFramework.DataProvider
{
    class ChannelMapper
    {
        private readonly static Dictionary<string, string> ChannelMap = new Dictionary<string, string>
        {
            ["Desktop"] = "desktop_windows"
        };

        public static string ToMapChannel(string channel)
        {
            return ChannelMap[channel];
        }
    }
}
