import React from "react";
import { NavLink } from "react-router-dom";
import {
  FaTachometerAlt,
  FaBoxOpen,
  FaPlus,
  FaShoppingCart,
  FaUsers,
  FaMoneyBillWave,
  FaTags,
  FaChartBar,
  FaCog,
  FaSignOutAlt,
} from "react-icons/fa";

const Sidebar = () => {
  return (
    <div className="h-screen bg-slate-800 text-white p-4 flex flex-col">
      
      {/* Logo */}
      <h2 className="text-xl font-bold mb-6">Admin Panel</h2>

      {/* Links */}
      <nav className="flex flex-col gap-2 flex-1">

        {[
          // { to: "/admin/dashboard", icon: <FaTachometerAlt />, label: "Dashboard" },
          { to: "/admin/products", icon: <FaBoxOpen />, label: "Products" },
          { to: "/admin/add-product", icon: <FaPlus />, label: "Add Product" },
          { to: "/admin/orders", icon: <FaShoppingCart />, label: "Orders" },
          { to: "/admin/users", icon: <FaUsers />, label: "Users" },
          { to: "/admin/payments", icon: <FaMoneyBillWave />, label: "Payments" },
          { to: "/admin/all-categories", icon: <FaTags />, label: "Categories" },
          { to: "/admin/reports", icon: <FaChartBar />, label: "Reports" },
          { to: "/admin/settings", icon: <FaCog />, label: "Settings" },
        ].map((item) => (
          <NavLink
            key={item.to}
            to={item.to}
            className={({ isActive }) =>
              `flex items-center gap-3 px-3 py-2 rounded-lg transition 
              ${isActive ? "bg-blue-600" : "hover:bg-slate-700"}`
            }
          >
            {item.icon}
            <span>{item.label}</span>
          </NavLink>
        ))}

      </nav>

      {/* Logout */}
      <NavLink
        to="/logout"
        className="flex items-center gap-3 px-3 py-2 rounded-lg hover:bg-red-600 mt-4"
      >
        <FaSignOutAlt />
        <span>Logout</span>
      </NavLink>

    </div>
  );
};

export default Sidebar;