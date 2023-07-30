using System;
using System.Collections.Generic;

namespace Hello_world
{
    public abstract class BaseShop<TProduct> : ISellable where TProduct : PeopleDescriptor
    {
        protected List<TProduct> _products = new List<TProduct>();
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

        private void Sort(AgeGroup age)
        {
            List<TProduct> _listProductsMatch = new List<TProduct>();
            foreach (var product in _products)
            {
                if (product.AgeGroup == age)
                {
                    _listProductsMatch.Add(product);
                }
            }

            Console.WriteLine($"I found {_listProductsMatch.Count} {age}s");
            foreach (var product in _listProductsMatch)
            {
                Console.WriteLine(
                    $"Name: {product.Name}, age: {product.Age}, price: {product.Price}, he is {product.AgeGroup}");
            }
        }

        public virtual void SellResponse()
        {
        }

        public abstract void SellRequest();
    }
}