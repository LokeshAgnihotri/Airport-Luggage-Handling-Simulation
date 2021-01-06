using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FollowPath
{
    public class Component
    {
        public ComponentType ComponentType { get; private set; }
        public Point CompenentType { get; private set; }
        public Image image { get; private set; }

        public Component(ComponentType componentType, Point compenentType, Image image)
        {
            this.ComponentType = componentType;
            this.CompenentType = compenentType;
            this.image = image;
        }
    }
}
