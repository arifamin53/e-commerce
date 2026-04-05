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
    <div className="sidebar">
      <h2 className="logo">Admin Panel</h2>

      <nav className="sidebar-links">
        <NavLink to="/admin/dashboard" className="nav-item">
          <FaTachometerAlt /> <span>Dashboard</span>
        </NavLink>

        <NavLink to="/admin/products" className="nav-item">
          <FaBoxOpen /> <span>Products</span>
        </NavLink>

        <NavLink to="/admin/add-product" className="nav-item">
          <FaPlus /> <span>Add Product</span>
        </NavLink>

        <NavLink to="/admin/orders" className="nav-item">
          <FaShoppingCart /> <span>Orders</span>
        </NavLink>

        <NavLink to="/admin/users" className="nav-item">
          <FaUsers /> <span>Users</span>
        </NavLink>

        <NavLink to="/admin/payments" className="nav-item">
          <FaMoneyBillWave /> <span>Payments</span>
        </NavLink>

        <NavLink to="/admin/categories" className="nav-item">
          <FaTags /> <span>Categories</span>
        </NavLink>

        <NavLink to="/admin/reports" className="nav-item">
          <FaChartBar /> <span>Reports</span>
        </NavLink>

        <NavLink to="/admin/settings" className="nav-item">
          <FaCog /> <span>Settings</span>
        </NavLink>

        <NavLink to="/logout" className="nav-item logout">
          <FaSignOutAlt /> <span>Logout</span>
        </NavLink>
      </nav>
    </div>
  );
};

export default Sidebar;