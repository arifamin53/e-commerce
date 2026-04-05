import React from "react";

const Header = () => {
  return (
    <div className="admin-header">
      <h1>Admin Dashboard</h1>
      <div className="admin-user">
        <img
          src="https://via.placeholder.com/40"
          alt="Admin"
          className="admin-avatar"
        />
        <span>Admin</span>
      </div>
    </div>
  );
};

export default Header;