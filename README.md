#** ASP.NET MVC WEB APP [Active Server Pages with Model-View-Controller Architectural Design] **#

Cascading Dropdowns for Countries, Cities, Postcodes, and Areas
This project implements cascading dropdowns for selecting countries, cities, postcodes, and areas in an ASP.NET MVC web application. The application retrieves data from an Oracle database using stored procedures and displays them dynamically via AJAX requests.

## **Features**
Country Dropdown: Populates city options based on the selected country.
City Dropdown: Populates postcode options based on the selected city.
Postcode Dropdown: Populates area options based on the selected postcode.
Key Files
View (Audit.cshtml): Contains the dropdown elements and JavaScript for loading options dynamically.

AJAX call to load area data based on the selected postcode.
Alerts and error handling for debugging and validation.
Controller (HomeController.cs):

**GetArea(string postcode_Id):** Retrieves area information based on the postcode_Id passed from the frontend.
Returns a JSON result for use in the AJAX success callback.
**Model (CityModel.cs):**
Represents the structure of the Area entity, including areaId and area.
Database (Oracle Stored Procedure):

**SP_GET_ALL_AREA:** Fetches area data based on the selected postcode_Id.
Setup Instructions
**Database:** Ensure that the Oracle database is set up with the required stored procedures (SP_GET_ALL_AREA).
**Backend:** Update your connection string and ensure that GetAreasByPostcodeId in the repository is connected to the database.
**Frontend:** The Audit.cshtml file includes AJAX logic for dynamic dropdowns. Make sure the IDs of the dropdown elements in the HTML match those in the JavaScript.
**Debugging**
Alerts have been added at key points in the AJAX calls and backend methods to track the flow of data and identify issues.
Common issues include incorrect postcode_Id being passed or empty responses from the database. Use browser developer tools to inspect the network requests.





