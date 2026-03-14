import { useEffect, useState } from "react";

function BowlerTable() {
  const [bowlers, setBowlers] = useState([]);

  useEffect(() => {
    fetch("https://localhost:7138/bowling")
      .then(res => res.json())
      .then(data => setBowlers(data));
  }, []);

  return (
    <table border="1">
      <thead>
        <tr>
          <th>Name</th>
          <th>Team</th>
          <th>Address</th>
          <th>City</th>
          <th>State</th>
          <th>Zip</th>
          <th>Phone</th>
        </tr>
      </thead>

      <tbody>
        {bowlers.map((b, index) => (
          <tr key={index}>
            <td>{b.firstName} {b.middle} {b.lastName}</td>
            <td>{b.team}</td>
            <td>{b.address}</td>
            <td>{b.city}</td>
            <td>{b.state}</td>
            <td>{b.zip}</td>
            <td>{b.phone}</td>
          </tr>
        ))}
      </tbody>
    </table>
  );
}

export default BowlerTable;