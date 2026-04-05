import React from "react";

const Dashboard = () => {
  return (
    <div>
      <h2>Dashboard</h2>
      <div className="cards">
        <div className="card">Total Products: 120</div>
        <div className="card">Total Orders: 45</div>
        <div className="card">Total Users: 80</div>
        <div className="card">Revenue: ₹50,000</div>
      </div>
    </div>
  );
};

export default Dashboard;