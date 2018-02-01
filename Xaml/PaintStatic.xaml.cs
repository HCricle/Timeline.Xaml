using Microsoft.Graphics.Canvas.UI;
using Microsoft.Graphics.Canvas.UI.Xaml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Timeline.Framework.Controller;
using Timeline.Framework.Drawing.PaintingSuface;
using Timeline.Framework.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//https://go.microsoft.com/fwlink/?LinkId=234236 上介绍了“用户控件”项模板

namespace Timeline.Framework.Xaml
{
    public partial class PaintStatic : UserControl
    {
        public PaintStatic()
        {
            this.InitializeComponent();
            Mouse.GetInstance(CurrentWindow.Window);
            Keyboard.GetInstance(CurrentWindow.Window);
        }
        private Book book;
        /// <summary>
        /// 故事书,也就是预定的整个游戏的故事
        /// </summary>
        public Book Book => book;
        /// <summary>
        /// 设置故事书
        /// </summary>
        /// <param name="b"></param>
        public void SetBook(Book b)
        {
            book = b;
        }
        private void Cc_Draw(CanvasControl sender, CanvasDrawEventArgs args)
        {
            var t = new CanvasTimingInformation();
            var d = new CanvasAnimatedDrawEventArgs(args.DrawingSession, t);
            book?.Update(sender, t);
            book?.Draw(sender, d);
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            Cc.RemoveFromVisualTree();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
        /// <summary>
        /// 更新画布
        /// </summary>
        public void UpdateCanvas()
        {
            Cc.Invalidate();
        }
    }
}
