import React, { useEffect, useState } from 'react'
import { Base_url } from '../../../constents/appUrls';
import { deleteCategory, getCategories } from '../../../service/categoryServices/categoryService';
import  "../../../components/CommonForm_css/table.css"
import { useNavigate } from 'react-router-dom';

const AllCategories = () => {
  const [categories, setCategories] = useState();
const navigate=useNavigate();
  const fetchingCategories = async () => {
    const response = await getCategories();
    if (response.isSuccess) {
      alert(response.message);
      setCategories(response.value)
    }
  }

  useEffect(() => {
    fetchingCategories();
  }, [])


  return (
    <div className="table-page">
      <div className="table-container">
        <h2 className="table-title">Category List</h2>

        <div className="table-responsive">
          <table className="admin-table">
            <thead>
              <tr>
                <th>Category Name</th>
                <th>Description</th>
                <th>Image</th>
                <th>Actions</th>
              </tr>
            </thead>

            <tbody>
              {
                categories && categories.map((item, index) => (
                  <tr key={index}>
                    <td>{item.name}</td>
                    <td>{item.description}</td>
                    <td>
                      <img
                        src={Base_url + item.filePath}
                        alt="category"
                        className="table-image"
                      />
                    </td>
                    <td>
                      <td>
                        <div className="table-actions">
                          <button className="view-btn">View</button>
                          <button className="edit-btn" onClick={()=>navigate(`/food-app/admin/edit-category/${item.id}`)}>Edit</button>
                          <button className="delete-btn" onClick={()=>deleteCategory(item.id)}>Delete</button>
                        </div>
                      </td>
                    </td>
                  </tr>
                ))
              }

            </tbody>
          </table>
        </div>
      </div>
    </div>
  )
}

export default AllCategories
