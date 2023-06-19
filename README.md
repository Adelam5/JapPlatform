# JAP Platform Backend

### Project Features
- Users have roles: Admin or Student
- Admin user is hard-coded in database
- Admin user can:
  - List all programs, selections and students
  - Filter selections and students by any of their attributes
  - Sort selections and students by any of their attributes
  - Results are paginated
  - Add, update, delete selections and students
  - Add and remove comments about students
  - Add and remove students to selections
  - Have access to Report about selections success rate and overall success rate
 - After student is created email with login credentials is sent to the user
 - Student user can:
  - Login with login credentials received by email
  - Access profile page
  - Logout

### Built with
#### Backend
- .NET 6 Web API
- Entity Framework Core
- SQL Server database
- Microsoft Identity
- Sendgrid
#### Frontend
- ReactJS
- React-Router-Dom
- React-Query
- Axios
- Formik
- Yup
- Zustand
- React-Bootstrap

### To get a local copy up and running follow these simple steps:
1. Clone the repo `https://github.com/Adela-me/JapTask1.git`
2. Open server folder with Visual Studio
3. To view a solution in Solution View `double click on JapTask1.snl` file
4. Run `dotnet ef database update` command from terminal (from JapTask1/server/server folder).
5. Fill in your Sendgrid data in appsettings.json
6. Start it with debbuging (F5) or without (Ctrl + F5)
7. You can test API with Swagger: `https://localhost:7257/swagger/index.html`
8. Install NPM packages `npm install` for frontend (from client folder)
9. Start frontend with `npm start`
10. Open `http://localhost:3000` to view application in the browser and login with:
    - Admin user: username: admin, password: admin
    - Student user: username: john, password: string

<a href="https://www.flaticon.com/free-icons/online-learning" title="online-learning icons">Icon created by Freepik - Flaticon</a>
