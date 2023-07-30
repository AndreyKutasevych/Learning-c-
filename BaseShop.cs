using System;

namespace Hello_world
{
    public abstract class BaseShop: ISellable
    {
        private Action _comeBackMenu;
        public BaseShop(Action comeBackMenu)
        {
            _comeBackMenu += comeBackMenu;
        }
        public abstract void Start();
        protected void ComeBackMenu()
        {
            _comeBackMenu?.Invoke();
        }

        public virtual void SellResponse()
        {

        }
        public abstract void SellRequest();
    }
}
