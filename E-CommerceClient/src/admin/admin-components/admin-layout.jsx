import React from "react";
import { Outlet } from "react-router-dom";

import "../admin.css";
import Sidebar from "./sidebar";
import Header from "./header";


const AdminLayout = () => {
  return (
    <div className="admin-container">
      <Sidebar />
      <div className="admin-main">
        <Header />
        <div className="admin-content">
          <Outlet />
        </div>
      </div>
    </div>
  );
};

export default AdminLayout;