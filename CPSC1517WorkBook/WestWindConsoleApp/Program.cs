using WestWindSystem.DAL;
using WestWindSystem.BLL;

var db = new WestWindContext();
var cs = new CustomerServices(db);

var customer = cs.GetCustomerById("ALFKI");

Console.WriteLine($"The first customer is {customer.ContactName}");