import React from "react";

export default function NewNote({ onAdd }) {
  return (
    <tr>
      <td />
      <td>new title</td>
      <td>new content</td>
      <td>
        <button onClick={onAdd}>Add</button>
      </td>
    </tr>
  );
}
