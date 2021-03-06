# Villa Plus

Pricing

A basket of items is a common ecommerce feature, allowing users to add several items to their virtual basket and pay for all the items at once. Merchants sometimes offer promotional discounts such as buy two, get one free for certain items or combinations of items. It is important to know the total price of all the items in a basket both to keep the customer informed as the basket is updated and to charge the right amount when paying for the basket. 
The solution calculates the total price of a given set of items and provides support by applying discount rules, specifically a “buy two, get one free” deal.

Implementation notes

- This is a simplified task implementation
- The DataAccess layer supplies the database-based implementations of the Domain classes.
- ProductRepository is an abstract class that in our case is implemented by the SqlProductRepository and the TestProductRepository
- ProductService class uses construction injection and the code is loosely coupled as it consumes the abstraction
- For this example I inject and use the TestProductRepository, for testing purposes. You could implement the SqlProductRepository or create another repository for data access 
- In a production application is preferable to use DI containers
- Promotions are handled by the ProductService and you can apply some minimal discount rules as starting and ending dates for the promotion to be valid, discount type, numbers of items required etc. More validations can be added and more rules to be introduced 
- For simplicity, the Basket class is calculating the discount but this functionality can be moved to another layer by creating, for example, a promotion/discount service. 
