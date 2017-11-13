import React from "react";
import Note from "./Note";
import NewNote from "./NewNote";

export default class Notes extends React.Component {
  constructor(props) {
    super(props);
    this.state = { notes: [] };
  }

  async componentDidMount() {
    this.refresh();
  }

  refresh = async () => {
    const res = await fetch("/api/notes");
    const notes = await res.json();
    this.setState(() => ({
      notes: notes
    }));
  };

  add = async () => {
    const note = {
      title: "title" + Math.round(Math.random() * 10),
      content: "content" + Math.round(Math.random() * 10)
    };
    await fetch("/api/notes", {
      method: "POST",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json"
      },
      body: JSON.stringify(note)
    });
    this.refresh();
  };

  save = async id => {
    const note = {
      id: id,
      title: "title" + Math.round(Math.random() * 10),
      content: "content" + Math.round(Math.random() * 10)
    };
    await fetch("/api/notes/" + id, {
      method: "PUT",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json"
      },
      body: JSON.stringify(note)
    });
    this.refresh();
  };

  delete = async id => {
    await fetch("/api/notes/" + id, {
      method: "DELETE"
    });
    this.refresh();
  };

  render() {
    const noteRows = this.state.notes.map(note => (
      <Note
        key={note.id}
        note={note}
        onSave={() => this.save(note.id)}
        onDelete={() => this.delete(note.id)}
      />
    ));
    return (
      <table>
        <thead>
          <tr>
            <th>Id</th>
            <th>Title</th>
            <th>Content</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {noteRows}
          <NewNote onAdd={this.add} />
        </tbody>
      </table>
    );
  }
}
