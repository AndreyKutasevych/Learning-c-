using System;

namespace Hello_world
{
    public abstract class BaseShop: ISellable
    {
        private Action _comeBackMenu;
        public BaseShop(Action _comeBackMenu)
        {
            this._comeBackMenu = _comeBackMenu;
        }
        public abstract void Start();
        private void ComeBackMenu()
        {

        }

        public virtual void SellResponse()
        {

        }
        public abstract void SellRequest();
    }
}
