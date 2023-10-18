using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xbim.Common;
using Xbim.Ifc;
using Xbim.Presentation;

namespace OrcamentosIfc.Forms
{
    /// <summary>
    /// Interação lógica para WinformsAccessibleControl.xam
    /// </summary>
    public partial class WinformsAccessibleControl : UserControl
    {
        public static readonly DependencyProperty ModelProviderProperty = DependencyProperty.Register("ModelProvider", typeof(ObjectDataProvider), typeof(WinformsAccessibleControl));

        #region DataContext

        public ObjectDataProvider ModelProvider
        {
            get { return (ObjectDataProvider)GetValue(ModelProviderProperty); }
            private set { SetValue(ModelProviderProperty, value); }
        }

        #endregion

        public IfcStore Model
        {
            get { return ModelProvider.ObjectInstance as IfcStore; }
        }

        public IPersistEntity SelectedElement
        {
            get => DrawingControl.SelectedEntity;
            set => DrawingControl.SelectedEntity = value;
        }

        public DrawingControl3D.SelectionBehaviours SelectionBehaviour
        {
            get => DrawingControl.SelectionBehaviour;
            set => DrawingControl.SelectionBehaviour = value;
        }

        public EntitySelection Selection
        {
            get => DrawingControl.Selection;
            set => DrawingControl.Selection = value;
        }

        public delegate void SelectionChangedHandler(object sender, System.Windows.Controls.SelectionChangedEventArgs e);

        public event SelectionChangedEventHandler SelectionChanged;

        public WinformsAccessibleControl()
        {
            InitializeComponent();
            ModelProvider = new ObjectDataProvider { IsInitialLoadEnabled = false };
        }

        private void DrawingControl_SelectedEntityChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            SelectionChanged?.Invoke(this, e);
        }
    }
}
