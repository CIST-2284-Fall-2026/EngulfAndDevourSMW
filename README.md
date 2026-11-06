# Program2SMW  
Project Overview:  
In the first part of this project, I build a Future Value Calculator Page. This update adds a Balance Sheet Page and Reserve Study Page. I will go over the new features, and post the old README files on the about page for consultation. The first page added is the Balance Sheet. It contains columns for Assets and Liabilities. The user can add/delete assets or liabilities from each column. The Balance Sheet will dynamically display total assets, liabilities, and equity. The user can also upload a balance sheet (not currently parsed per instructions) and save the filename and a timestamp. The user can also download the displayed balance sheet to a .docx file. The Reserve Study page contains a list of components. The user can add/delete items from this list. If there are components in the list, the Reserve Study page will dynamically create a line graph of yearly expenses over the 30 year study horizon, as well as displaying total costs over the 30 year study and a recommended monthly HOA fee per unit. The user can also change the number of units, dynamically updating calculations. Additionally, the user can import a .csv file to populate the list of components as well as exporting the current component list to a .csv file.  
  
How to run:  
Running the project from VS Code will start it up on a local server, which can be visited in a browser's address bar. This will take you to the home page with a navigation menu on the right. Clicking a page will take you there.  
  
On the balance sheet page, you can add an asset or liability by clicking the associated buttons. You will see a form with several input fields. Fill it in and click submit, and it will be added to the list. To remove an asset or liability, click delete next to that line item. You will be asked if you are sure, click yes or no. To download the currently displayed balance sheet, click download balance sheet, and a .docx file will be created and downloaded. To upload a file, click Upload Balance Sheet.  
  
On the reserve study page, you can add a component by clicking Add Component. You will see a form with several input fields. Fill it in and click submit, and it will be added to the list. To remove a component, click delete next to that component. You will be asked if you are sure, clikc yes or not. To download the currently displayed component list, click export to .csv file. To import a component list to be displayed, click import .csv file.  
  
Page Map:  
  
Home - /  
    Future Value Calculator - /future-value    
	Balance Sheet - /balance-sheet    
	Reserve Study - /reserve-study    
  
Component Breakdown:  
This project uses separate page components for each page. Bootstrap components are used for forms (EditForm), data validation (DataAnnotationsValidator, ValidationSummary), data inputs (InputText, InputNumber), file upload (InputFile), and tab titles (PageTitle). Other "components" created include two new JavaScript files in wwwroot. These define functions called for downloading files from the browser and building the line chart for the reserve study.  
  
Where State Lives:  
Each page has its own state living in model classes. I kept the forms on their parent pages for a simpler architecture. In the future, I will use things like modals for forms that will pass state from parent to child through parameters, and back up through event callbacks.   
  
Testing Summary:  
I created six unit tests for each service. This is because each service ended up with three methods. Each method was tested using normal numbers and hand calculations, as well as testing the results when inputting empty lists and zero values. One method throws an error if it is going to try to divide by zero; that was tested as well.  
  
AI Usage Disclosure:  
ChatGPT was used throughout the project to help with ideation and scaffolding. There are very few places where I simply copy/pasted output from ChatGPT - the vast majority of the code is my own. The places where I utilized ChatGPT the most were for file upload/download and creating a line graph, as neither of these have been addressed in the classroom. In this case, the AI provided two javascript files for me: chart.js and download.js. The functions within create a chart or download a .docx/.csv. I also had to install the dotnet OpenXML SDK in order to write to .docx. Chat also walked me through the C# methods for downloading/writing a file. The sections with AI-produced code will be commented as such. 