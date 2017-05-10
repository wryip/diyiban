using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Commond
{
    public static class SuccessInfo
    {
        public static void Success()
        {
            SoundPlayer p = new SoundPlayer();
            p.SoundLocation = Application.StartupPath+"//finish.wav";
            p.Load();
            p.Play();
        }
    }
}
