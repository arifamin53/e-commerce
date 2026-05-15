import React from "react";
import { Outlet } from "react-router-dom";
import Sidebar from "./sidebar";
import Header from "./header";

const AdminLayout = () => {
  return (
    <div className="flex h-screen overflow-hidden">
      
      {/* 🔥 Sidebar */}
      <div className="w-[250px] flex-shrink-0">
        <Sidebar />
      </div>

      {/* 🔥 Right Section */}
      <div className="flex-1 flex flex-col overflow-hidden">
        
        {/* 🔥 Header */}
        <div className="h-[60px] flex-shrink-0">
          <Header />
        </div>

        {/* 🔥 Content */}
        <div className="flex-1 overflow-hidden bg-gray-100 p-4">
          <div className="h-full overflow-auto">
            <Outlet />
          </div>
        </div>

      </div>
    </div>
  );
};

export default AdminLayout;