# Program2SMW  
Project Overview:  
The goal of this project is to make a simple Blazor web page with a Home page and navigation to a Future Value Calculator. The user should be able to input values for Principal, Interest Rate, Years, and Compounds Per Year. When the user clicks submit, these values will be stored in a model class object, and that will be used to calculate the future value and return that to the user. This project uses an EditForm, a model class, data binding, and unit testing.  

How to run:  
You should be able to run this project as is from VS Code. When you navigate to the local web address, you will see a simple home page with a navigation menu on the left side. Currently, the only other pages are "Future Value Calculator" and "About" (located at the top right). At Future Value Calculator, you can input values for Principal, Annual Interest Rate, Number of Years, and Number of Compounds Per Year. Once you have input values, click submit to see a summary of the results. At the about page, you will see my information and a copy of this README.  
  
Page map/routing:  
There are only three pages: A home page, a future value calculator page, and an about page.  
The home page is located at localhost:[port]  
The future value calculator page is located at localhost:[port]/future-value  
The about page is located at localhost:[port]/about  
Both main pages can be visited by clicking links in the navigation menu. The about page can be visited by clicking about in the top right corner.    
  
Component Breakdown:  
This project contains many default components from blazor, namely MainLayout and NavMenu. I edited NavMenu to only include the pages used in this project. I removed most of the default pages, but left Error.razor and NotFound.razor for future implementation. I also had to edit MainLayout to reroute the about page.    
  
Where State Lives/How it Flows:  
This all takes place in the Future Value Calculator page. When the page loads, the input fields are bound to a future value model class object which has variable for each of the input fields. When the user inputs data, it is stored in the object, which calculates the future value. Then, when the user clicks submit, the message variable is changed to reflect the user inputs and the calculated result.   
  
Testing Summary:  
I tested the calculations with standard inputs, as well as zero values and negative values for each variable. Input validation is in place to prevent these values, but the class methods handle these edge cases as well.  

AI Usage Disclosure (and other sources):  
ChatGPT was used sparingly when I got stuck debugging or wanted to understand a concept better. It didn't produce any of my code or any other output you see. I got the accounting stock photo from https://www.istockphoto.com/photos/accounting.  