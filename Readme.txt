I started by thinking how I would aproach the program in a piece of papper where I did an approach to the UML diagram to see wich classes and methods I would need.
I tried to keep in mind that the program could be expanded creating another kind of persons with different options or more bank accounts to the same customer.
When creating the UML diagram: 
I have created the instance IPerson (mainly to by sure that every person have to have a Login). 
An abstract class Person that inherits the IPerson, to manage the lodge, withdraws and logout.
Customer class that inherits Person, to manage customer information, login and  has attached the objects of their bank accounts.
Employee class that inherits Person, that manages all the methods an Employee can perform.
Bank Account class to keep all the info of a bank account Current and Savings are 2 objects of bank account
Filemanaging is a class to keep all the methods to write, read, print and delete files and a method to Write changes in Customers.txt
The main program first creates/load all the customers depending on if Customers.txt exist or not, after that there is two nested do whiles with and if for customer/employee and 
a switch to show and manage the options for the users.

When I started doing the program I wanted to manage everything by using objects and classes and just load the info from customers and bank accounts from existent files,
so I did all the program based in those objects and after everithing was working, I was manual testing the program while doing it step by step using the comandline 
but mainly i tested the read/write files for create a customer option. I did not create a testing unit mainly because I never did it and I did not know how to aproach it. Since my methods have also inputs/outputs inside
to test for example lodge I have to put all the data on the console, I think in order to have a testing module I would have to separate the output/input from the method that
does the changes and contrast if the info of one object is the same to the information that should have.

I tried to avoid repited code but I'm sure I can polish it, withdraw/lodge are to similar I could put both of them in one method with an if statement to chose between lodge/withdraw.
I tried to manage all the accesses to accounts by account number but the customer has to enter their name also so it did not make so much sense after all

