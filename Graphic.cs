using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WPF_GameAnimationDemo
{
    class Graphic
    {
        /// <summary>
        /// 绘制层
        /// </summary>
        public readonly WriteableBitmap RenderTarget;

        /// <summary>
        /// 绘制队列
        /// </summary>
        protected readonly List<IDrawable> DrawQueue = new List<IDrawable>();

        public Graphic(Image canvas)
        { 
            RenderTarget = BitmapFactory.New((int)canvas.Width, (int)canvas.Height);
        }

        /// <summary>
        /// 接收用户操作
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void OnMouseClick(int x, int y)
        {
            // 在鼠标点击的位置创建一个爆炸动画   
            DrawQueue.Add(new Explode(x, y));
        }

        /// <summary>
        /// 渲染
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnRending(object sender, EventArgs e)
        {
            // 清空画布
            RenderTarget.Clear(Colors.White);

            // 清空失效的绘制对象
            DrawQueue.RemoveAll(item => !item.IsAlive);

            // 绘制队列中的所有项
            DrawQueue.ForEach(item => item.Draw(RenderTarget));
        }
    }
}
