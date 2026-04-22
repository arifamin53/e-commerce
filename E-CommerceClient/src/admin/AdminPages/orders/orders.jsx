import React, { useEffect, useState } from "react";
import {
  getOrderByStatus,
  updateOrderStatus,
} from "../../../service/orderService/orderService";

const AdminOrders = () => {
  const [orders, setOrders] = useState([]);
  const [filter, setFilter] = useState("All");
  const [loading, setLoading] = useState(false);

  // 🔥 Status Mapping
  const OrderStatus = {
    1: "Pending",
    2: "Confirmed",
    3: "Canceled",
    4: "Shipped",
    5: "Paid",
  };

  // 🔹 Fetch Orders
  const fetchOrders = async () => {
    try {
      setLoading(true);
      const response = await getOrderByStatus();

      if (response.isSuccess) {
        setOrders(response.value);
      }
    } catch (err) {
      console.error(err);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchOrders();
  }, []);

  // 🔹 Filter Logic (FIXED 🔥)
  const filteredOrders =
    filter === "All"
      ? orders
      : orders.filter(
          (o) => OrderStatus[o.status] === filter
        );

  // 🔹 Status Update (FIXED 🔥)
  const handleStatusChange = async (id, newStatus) => {
    try {
      await updateOrderStatus(id, newStatus);

      setOrders((prev) =>
        prev.map((o) =>
          o.id === id
            ? {
                ...o,
                status:
                  Object.keys(OrderStatus).find(
                    (key) => OrderStatus[key] === newStatus
                  ) || o.status,
              }
            : o
        )
      );
    } catch (err) {
      console.error("Failed to update status", err);
    }
  };

  return (
    <div className="p-4 sm:p-6">
      {/* 🔥 Filter Buttons */}
      <div className="flex flex-wrap gap-2 mb-4">
        {["All", "Pending", "Confirmed", "Shipped", "Canceled", "Paid"].map(
          (status) => (
            <button
              key={status}
              onClick={() => setFilter(status)}
              className={`px-4 py-2 rounded-lg text-sm font-medium transition
                ${
                  filter === status
                    ? "bg-blue-600 text-white"
                    : "bg-gray-100 text-gray-700 hover:bg-gray-200"
                }`}
            >
              {status}
            </button>
          )
        )}
      </div>

      {/* 🔥 Table */}
      <div className="overflow-x-auto bg-white shadow-md rounded-2xl">
        <table className="min-w-full text-sm text-left">
          <thead className="bg-gray-100 text-gray-700 uppercase text-xs">
            <tr>
              <th className="px-4 py-3">Name</th>
              <th className="px-4 py-3">Email</th>
              <th className="px-4 py-3">Contact</th>
              <th className="px-4 py-3">City</th>
              <th className="px-4 py-3">State</th>
              <th className="px-4 py-3">Country</th>
              <th className="px-4 py-3">Street</th>
              <th className="px-4 py-3">Zip</th>
              <th className="px-4 py-3">Amount</th>
              <th className="px-4 py-3">Date</th>
              <th className="px-4 py-3">Action</th>
            </tr>
          </thead>

          <tbody className="divide-y">
            {loading ? (
              <tr>
                <td colSpan="11" className="text-center py-6">
                  Loading...
                </td>
              </tr>
            ) : filteredOrders.length === 0 ? (
              <tr>
                <td colSpan="11" className="text-center py-6">
                  No orders found
                </td>
              </tr>
            ) : (
              filteredOrders.map((order) => {
                const status = OrderStatus[order.status]; // ✅ FIXED

                return (
                  <tr
                    key={order.id}
                    className="hover:bg-gray-50 transition"
                  >
                    <td className="px-4 py-3">{order.name}</td>
                    <td className="px-4 py-3">{order.email}</td>
                    <td className="px-4 py-3">{order.contactNo}</td>
                    <td className="px-4 py-3">{order.city}</td>
                    <td className="px-4 py-3">{order.state}</td>
                    <td className="px-4 py-3">{order.country}</td>
                    <td className="px-4 py-3">{order.street}</td>
                    <td className="px-4 py-3">{order.zipCode}</td>
                    <td className="px-4 py-3 font-semibold">
                      ₹{order.totalAmount}
                    </td>
                    <td className="px-4 py-3">{order.orderDate}</td>

                    {/* 🔥 Action Button */}
                    <td className="px-4 py-3">
                      {status === "Pending" && (
                        <button
                          onClick={() =>
                            handleStatusChange(order.id, "Confirmed")
                          }
                          className="px-3 py-1 text-xs bg-yellow-100 text-yellow-700 rounded-lg hover:bg-yellow-200"
                        >
                          Confirm
                        </button>
                      )}

                      {status === "Confirmed" && (
                        <button
                          onClick={() =>
                            handleStatusChange(order.id, "Shipped")
                          }
                          className="px-3 py-1 text-xs bg-blue-100 text-blue-700 rounded-lg hover:bg-blue-200"
                        >
                          Ship Order
                        </button>
                      )}

                      {status === "Shipped" && (
                        <span className="px-3 py-1 text-xs bg-green-100 text-green-700 rounded-lg">
                          Shipped
                        </span>
                      )}

                      {status === "Canceled" && (
                        <span className="px-3 py-1 text-xs bg-red-100 text-red-700 rounded-lg">
                          Canceled
                        </span>
                      )}

                      {status === "Paid" && (
                        <span className="px-3 py-1 text-xs bg-green-200 text-green-800 rounded-lg">
                          Paid
                        </span>
                      )}
                    </td>
                  </tr>
                );
              })
            )}
          </tbody>
        </table>
      </div>
    </div>
  );
};

export default AdminOrders;