# Engulf&DevourSMW
This update doesn't add any new features - instead it implements Blazor components on the pages that have been built so far. I will go page by page and list the components added, as well as what they do and how state flows.   
  
Future Value Page:  
FutureValueInputs.razor - This displays the input fields for future value inputs. The parent component passes in a FutureValue object as a parameter. This object will hold the future value data input into the form. The component also has an EventCallback called OnValidSubmit. When the user submits the form, a method is called that then invokes whatever method is assigned to it by the parent component.  

FutureValueResults.razor - This just displays a message. That message is passed in by the parent component as a parameter. This component has no event callbacks, the data only passes one way.  
  
Balance Sheet Page:  
BalanceSheetList.razor - This displays the list of assets and liabilities from the balance sheet, their totals, and total equity. The parent component passes in the balance sheet object as well as equity as a parameter. There are four event callbacks. OnDeleteAsset is tied to a parent method to delete a given asset. OnDeleteLiability is the same but for a liability. They both also pass a specific line item back to the parent representing the line item to be deleted. OnAddAsset and OnAddLiability are tied to respective parent methods to add an asset or a liability.  
  
BalanceSheetItemDialog.razor - This displays the input form to add a line item (asset or liability) to the balance sheet. It receives a line item as a parameter. There are two event callbacks - OnValidSubmit and OnCancel. They are tied to their respective parent methods to either add the line item or cancel.  
  
Reserve Study Page:  
ReserveStudyFilters.razor - This displays the non-component values of the reserve study (Study Horizon, a fixed value, and Number of Units, which the user can edit). The reserve study object is passed in as a parameter. There is an editform that is shown if the user clicks edit next to number of units. There is an event callback tied to a method that just causes the parent component to re-render, updating study calculations if they have changed.  
  
ReserveItemList.razor - This displays the list of components in the reserve study. The study is passed in as a parameter. There are two event callbacks: OnDeleteComponent and OnAddComponent. OnDeleteComponent is tied to a parent method to delete a component and it passes the component to be deleted. OnAddComponent also calls a parent method to initiate adding a new component.  
  
ReserveItemDialog.razor - This displays an edit form to add a new component to the list of components. The model component is passed in by the parent. There is an event callback that is tied to a parent method to add a new component.  
  
YearlyTotalsChart.razor - This displays the line graph tracking annual expenses. The study is passed in as a parameter from the parent. There is no event callback as no data is sent back to the parent. Whenever parameters are set, annual expenditures are calculated and a redraw of the chart is triggered. No chart is displayed if there are no items in the components list. Note: The assignment labels the the MonthlyTotalsChart, but the previous assignment had us doing annual expenditures, not monthly, so I will stick with that.  
  
AI Usage: ChatGPT was used in the debugging process and to help with ideation. It did not contribute meaningfully to the code itself, but it did save me time debugging.
