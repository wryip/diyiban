using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace yixiupige
{
    public static class SuccessInfo
    {
        public static void Success()
        {
            SoundPlayer p = new SoundPlayer(Properties.Resources.ResourceManager.GetStream("finish"));
            //p.SoundLocation = "..//..//Info//finish.wav";
            p.Load();
            p.Play();
        }
    }
}
