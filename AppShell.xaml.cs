namespace PhotoOrganizer {
    public partial class AppShell : Shell {
        public AppShell() {
            InitializeComponent();
#if WINDOWS
            var tabBar = (TabBar)Items.First();

            tabBar.Items.RemoveAt(0);
            CurrentItem = tabBar.Items.First();

            SetTabBarIsVisible(this, false);
#endif
        }
    }
}