using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.UI;
using Microsoft.Graphics.Canvas.UI.Xaml;
using System;
using System.Collections.Generic;
using Timeline.Framework.Controller;
using Timeline.Framework.Drawing;
using Timeline.Framework.Drawing.PaintingSuface;
using Timeline.Framework.Input;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace Timeline.Framework.Xaml
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public partial class PaintPlane : UserControl
    {
        public PaintPlane()
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
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Cac.RemoveFromVisualTree();            
        }

        private void Cac_Draw(ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args)
        {
            Book?.Draw(sender, args);
        }

        private void Cac_Update(ICanvasAnimatedControl sender, CanvasAnimatedUpdateEventArgs args)
        {
            Book?.Update(sender, args.Timing);
        }
    }
}
