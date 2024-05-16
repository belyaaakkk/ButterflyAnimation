using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using System.Windows.Media.Animation;

namespace ButterflyAnimation
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Обробник події для кнопки "Start Animation"
        private void StartAnimation_Click(object sender, RoutedEventArgs e)
        {
            AnimateButterfly();
        }

        private void AnimateButterfly()
        {
            // Отримуємо модель метелика зі сцени
            ModelVisual3D visual3D = (ModelVisual3D)mainViewport.Children[0];
            Model3DGroup butterflyModel = (Model3DGroup)visual3D.Content;

            // Створюємо анімацію руху метелика вздовж вісі Y (вгору-вниз)
            DoubleAnimation yAnimation = new DoubleAnimation();
            yAnimation.From = 0; // Початкове значення
            yAnimation.To = 360;   // Кінцеве значення
            yAnimation.Duration = TimeSpan.FromSeconds(2); // Тривалість анімації
            yAnimation.AutoReverse = true; // Анімація в обидві сторони

            // Встановлюємо цільову властивість для анімації
            Rotation3D rotation = new AxisAngleRotation3D(new Vector3D(0, 1, 0), 0);
            butterflyModel.Transform = new RotateTransform3D(rotation);

            // Запускаємо анімацію
            rotation.BeginAnimation(AxisAngleRotation3D.AngleProperty, yAnimation);
        }
    }
}
