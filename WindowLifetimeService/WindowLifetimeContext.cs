using System;
using System.Collections.Generic;
using System.Windows;


namespace WindowLifetimeService
{
    public class WindowLifetimeContext : IDisposable
    {
        private readonly Window _window;
        private readonly WindowLifetimeContext _childsOwner;
        private readonly List<WindowLifetimeContext> _childs = new List<WindowLifetimeContext>();

        public WindowLifetimeContext(Window window, WindowLifetimeContext childsOwner = null)
        {
            _window = window;
            _childsOwner = childsOwner ?? this;

            _window.Closed += OnWindowClosed;
        }

        private void OnWindowClosed(object sender, EventArgs e)
        {
            foreach (var child in _childs.ToArray())
                child.Dispose();
            OnDispose?.Invoke(this);
        }
        public void Dispose()
        {
            _window.Close();
        }
        public event Action<WindowLifetimeContext> OnDispose;

        protected void CreateWindow(WindowLifetimeContext window, bool setOwner = false)
        {
            //Owner работает странно - он сам сворачивает/закрывает своих детей и группирует в одну иконку когда свернуты, 
            //но не дает быть поверх детей и скрывает овнера, если чайлд был закрыт при наличии чайлдов у него (баг?)
            if(setOwner)
            {
                window._window.Owner = _window;
                window._window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            }
            else
            {
                _childsOwner._childs.Add(window);
                window._window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            }
            window.OnDispose += OnChildDisposed;
            window._window.Show();
        }

        private void OnChildDisposed(WindowLifetimeContext child)
        {
            child.OnDispose -= OnChildDisposed;
            _childsOwner._childs.Remove(child);
        }
    }
}
