using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WPF_GameAnimationDemo
{
    interface IDrawable
    {
        bool IsAlive { get; set; }

        void Draw(WriteableBitmap renderTarget);
    }
}
