import React from "react";
import Notes from "./Notes";
import "./App.css";

export default function App() {
  return (
    <div>
      <header>
        <h1>Notepad</h1>
      </header>
      <div className="content">
        <Notes />
      </div>
      <footer>&copy; Bart Wijnants</footer>
    </div>
  );
}
