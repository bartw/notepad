import React from "react";

export default function Note({ note, onSave, onDelete }) {
  return (
    <tr>
      <td>{note.id}</td>
      <td>{note.title}</td>
      <td>{note.content}</td>
      <td>
        <button onClick={onSave}>Save</button>
        <button onClick={onDelete}>Delete</button>
      </td>
    </tr>
  );
}
