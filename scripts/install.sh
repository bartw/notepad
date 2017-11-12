cd frontend
npm install
cd ..
dotnet restore ./backend/Notes.Domain
dotnet restore ./backend/Notes.Data.EfCore
dotnet restore ./backend/Notes.Web