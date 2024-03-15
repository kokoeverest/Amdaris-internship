﻿namespace Collections
{
    public class Customer : Entity
    {
        public string? Name { get; set; }
        public bool hasPaid;
        private List<Entity> _cars;

        public Customer(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
            this._cars = [];
        }

        public List<Entity>? Cars { get => _cars; set { } }
    }
}
