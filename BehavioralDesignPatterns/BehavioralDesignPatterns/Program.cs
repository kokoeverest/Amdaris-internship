using BehavioralDesignPatterns.Models;
using BehavioralDesignPatterns.Observers;

// Assignment requirements
// You are tasked with designing and implementing an order processing system for an online bookstore.
// The system should allow users to place orders for books and process those orders efficiently.
// Your implementation should focus on applying a specific behavioral design pattern that addresses
// the requirements of the scenario.

// Functional Requirements:

// 1. When a customer places an order, they should receive notifications about the order status updates via
// email or SMS (Use just Console.WriteLine to simulate sending and email or SMS)
// 2. Staff members responsible for order fulfillment should receive notifications when new orders are
// placed and when orders are ready for shipping.
// 3. Implement a mechanism for customers and staff to subscribe or unsubscribe from order status notifications.
// 4. Everything should be implemented in one single console application

BookStore bookStore = new();
Book book1 = new("Hitchhiker's guide to universe", "Douglas Adams");
Book book2 = new("Pod Igoto", "Ivan Vazov");
Book book3 = new("It", "Stephen King");
Book book4 = new("Clean code", "Code Master");

Customer customer1 = new("Ivan Ivanov", "random@mail.con", "1234567890");
Customer customer2 = new("Petar Petrov", "domrand@mal.con", "1234567890");

StaffMember member1 = new("Georgi Hristov", "hristovgeorgi@mail.con", "1234567890");
StaffMember member2 = new("Hristo Georgiev", "georgievh@mail.con", "1234567890");

bookStore.AddBooks([book1, book2, book3, book4]);
bookStore.AddStaffMember(member1);
bookStore.AddStaffMember(member2);

bookStore.Unsubscribe(subscriber: member1, email: true, phone: false);

customer1.BuyProduct(bookStore, book2);
bookStore.Unsubscribe(subscriber: customer1, email: false, phone: true);

customer2.BuyProduct(bookStore, book1);
customer1.BuyProduct(bookStore, book3);


customer1.BuyProduct(bookStore, book4);
customer2.BuyProduct(bookStore, book4);
await bookStore.ProccessOrders([1, 3]);
await bookStore.ProccessOrders([2, 4]);


