import React, { useState } from 'react'
import { Pencil, Trash2, Tag, FileText, Save, X, ImageIcon } from 'lucide-react'

const EditCategory = () => {
  const [isEditing, setIsEditing] = useState(false)

  const [category, setCategory] = useState({
    name: 'Electronics',
    description:
      'All electronic items like mobiles, laptops, smart watches, accessories, headphones, gadgets, and more.',
    image:
      'https://images.unsplash.com/photo-1519389950473-47ba0277781c?w=1200&q=80',
    status: 'Active',
    products: 24,
    createdAt: '12 March 2026',
  })

  const [formData, setFormData] = useState(category)

  const handleChange = (e) => {
    const { name, value } = e.target
    setFormData((prev) => ({
      ...prev,
      [name]: value,
    }))
  }

  const handleSave = () => {
    setCategory(formData)
    setIsEditing(false)
  }

  const handleCancel = () => {
    setFormData(category)
    setIsEditing(false)
  }

  const handleDeleteImage = () => {
    setFormData((prev) => ({
      ...prev,
      image: '',
    }))
  }

  return (
    <div className="min-h-screen bg-gradient-to-br from-slate-100 via-slate-50 to-slate-200 p-4 sm:p-6 lg:p-8">
      <div className="max-w-7xl mx-auto">
        {/* Top Header */}
        <div className="mb-8 rounded-3xl bg-white shadow-sm border border-slate-200 p-6 sm:p-8">
          <div className="flex flex-col lg:flex-row lg:items-center lg:justify-between gap-5">
            <div>
              <p className="text-sm font-medium text-blue-600 mb-2">
                Admin / Categories / {isEditing ? 'Edit' : 'Details'}
              </p>
              <h1 className="text-3xl sm:text-4xl font-bold text-slate-800 tracking-tight">
                {isEditing ? 'Edit Category' : 'Category Details'}
              </h1>
              <p className="text-slate-500 mt-2 text-sm sm:text-base max-w-2xl">
                View category information, manage details, and update image or metadata from this dashboard page.
              </p>
            </div>

            {!isEditing ? (
              <button
                onClick={() => setIsEditing(true)}
                className="inline-flex items-center justify-center gap-2 rounded-2xl bg-blue-600 px-6 py-3 text-white font-semibold shadow-md hover:bg-blue-700 transition-all duration-200"
              >
                <Pencil size={18} />
                Edit Category
              </button>
            ) : (
              <div className="flex flex-col sm:flex-row gap-3">
                <button
                  onClick={handleCancel}
                  className="inline-flex items-center justify-center gap-2 rounded-2xl border border-slate-300 bg-white px-5 py-3 text-slate-700 font-medium hover:bg-slate-50 transition"
                >
                  <X size={18} />
                  Cancel
                </button>
                <button
                  onClick={handleSave}
                  className="inline-flex items-center justify-center gap-2 rounded-2xl bg-emerald-600 px-5 py-3 text-white font-semibold shadow-md hover:bg-emerald-700 transition"
                >
                  <Save size={18} />
                  Save Changes
                </button>
              </div>
            )}
          </div>
        </div>

        {/* Main Grid */}
        <div className="grid grid-cols-1 xl:grid-cols-3 gap-6">
          {/* LEFT SIDE */}
          <div className="xl:col-span-1 space-y-6">
            {/* Image Card */}
            <div className="bg-white rounded-3xl shadow-sm border border-slate-200 overflow-hidden">
              <div className="px-6 py-5 border-b border-slate-200 flex items-center justify-between">
                <h2 className="text-lg font-semibold text-slate-800">Category Image</h2>
                <span className="text-xs font-medium px-3 py-1 rounded-full bg-slate-100 text-slate-600">
                  Preview
                </span>
              </div>

              <div className="p-5">
                <div className="relative group rounded-3xl overflow-hidden bg-slate-100 border border-slate-200">
                  {formData.image ? (
                    <img
                      src={formData.image}
                      alt="Category"
                      className="w-full h-[260px] sm:h-[320px] object-cover"
                    />
                  ) : (
                    <div className="w-full h-[260px] sm:h-[320px] flex flex-col items-center justify-center text-slate-400">
                      <ImageIcon size={50} className="mb-3" />
                      <p className="font-medium">No Image Available</p>
                    </div>
                  )}

                  {/* Overlay */}
                  <div className="absolute inset-0 bg-black/10 opacity-0 group-hover:opacity-100 transition duration-300"></div>

                  {/* Action Buttons */}
                  <div className="absolute top-4 right-4 flex gap-3">
                    <button
                      className="w-11 h-11 rounded-full bg-white/95 backdrop-blur flex items-center justify-center shadow-lg hover:scale-105 transition"
                      title="Edit Image"
                    >
                      <Pencil size={18} className="text-slate-700" />
                    </button>

                    <button
                      onClick={handleDeleteImage}
                      className="w-11 h-11 rounded-full bg-red-500 flex items-center justify-center shadow-lg hover:bg-red-600 hover:scale-105 transition"
                      title="Delete Image"
                    >
                      <Trash2 size={18} className="text-white" />
                    </button>
                  </div>
                </div>

                <p className="text-sm text-slate-500 mt-4">
                  Upload a high-quality category banner or square preview image for better presentation.
                </p>
              </div>
            </div>

            {/* Quick Stats */}
            <div className="grid grid-cols-1 sm:grid-cols-3 xl:grid-cols-1 gap-4">
              <div className="bg-white rounded-3xl border border-slate-200 shadow-sm p-5">
                <p className="text-sm text-slate-500">Status</p>
                <p className="mt-2 text-xl font-bold text-emerald-600">{category.status}</p>
              </div>

              <div className="bg-white rounded-3xl border border-slate-200 shadow-sm p-5">
                <p className="text-sm text-slate-500">Products</p>
                <p className="mt-2 text-xl font-bold text-slate-800">{category.products} Items</p>
              </div>

              <div className="bg-white rounded-3xl border border-slate-200 shadow-sm p-5">
                <p className="text-sm text-slate-500">Created</p>
                <p className="mt-2 text-lg font-semibold text-slate-800">{category.createdAt}</p>
              </div>
            </div>
          </div>

          {/* RIGHT SIDE */}
          <div className="xl:col-span-2">
            <div className="bg-white rounded-3xl shadow-sm border border-slate-200 overflow-hidden">
              <div className="px-6 py-5 border-b border-slate-200">
                <h2 className="text-xl font-semibold text-slate-800">
                  {isEditing ? 'Edit Information' : 'Category Information'}
                </h2>
                <p className="text-sm text-slate-500 mt-1">
                  {isEditing
                    ? 'Update category details and save changes.'
                    : 'Review the current category information below.'}
                </p>
              </div>

              <div className="p-6 sm:p-8 space-y-8">
                {/* Name */}
                <div>
                  <label className="flex items-center gap-2 text-sm font-semibold text-slate-700 mb-3">
                    <Tag size={16} className="text-blue-600" />
                    Category Name
                  </label>

                  {isEditing ? (
                    <input
                      type="text"
                      name="name"
                      value={formData.name}
                      onChange={handleChange}
                      placeholder="Enter category name"
                      className="w-full rounded-2xl border border-slate-300 bg-slate-50 px-4 py-4 text-slate-800 outline-none focus:border-blue-500 focus:ring-4 focus:ring-blue-100 transition"
                    />
                  ) : (
                    <div className="w-full rounded-2xl border border-slate-200 bg-slate-50 px-4 py-4 text-slate-800 font-medium">
                      {category.name}
                    </div>
                  )}
                </div>

                {/* Description */}
                <div>
                  <label className="flex items-center gap-2 text-sm font-semibold text-slate-700 mb-3">
                    <FileText size={16} className="text-blue-600" />
                    Description
                  </label>

                  {isEditing ? (
                    <textarea
                      name="description"
                      rows="7"
                      value={formData.description}
                      onChange={handleChange}
                      placeholder="Enter category description"
                      className="w-full rounded-2xl border border-slate-300 bg-slate-50 px-4 py-4 text-slate-800 outline-none resize-none focus:border-blue-500 focus:ring-4 focus:ring-blue-100 transition"
                    />
                  ) : (
                    <div className="w-full min-h-[180px] rounded-2xl border border-slate-200 bg-slate-50 px-4 py-4 text-slate-700 leading-7">
                      {category.description}
                    </div>
                  )}
                </div>

                {/* Extra Admin Metadata */}
                <div className="grid grid-cols-1 md:grid-cols-2 gap-5">
                  <div className="rounded-2xl border border-slate-200 bg-slate-50 p-5">
                    <p className="text-sm text-slate-500">Last Updated By</p>
                    <p className="mt-2 text-lg font-semibold text-slate-800">Admin User</p>
                  </div>

                  <div className="rounded-2xl border border-slate-200 bg-slate-50 p-5">
                    <p className="text-sm text-slate-500">Last Modified</p>
                    <p className="mt-2 text-lg font-semibold text-slate-800">09 April 2026</p>
                  </div>
                </div>

                {/* Mobile Buttons */}
                {isEditing && (
                  <div className="flex flex-col sm:flex-row gap-4 xl:hidden pt-2">
                    <button
                      onClick={handleCancel}
                      className="w-full inline-flex items-center justify-center gap-2 rounded-2xl border border-slate-300 bg-white px-5 py-3 text-slate-700 font-medium hover:bg-slate-50 transition"
                    >
                      <X size={18} />
                      Cancel
                    </button>
                    <button
                      onClick={handleSave}
                      className="w-full inline-flex items-center justify-center gap-2 rounded-2xl bg-emerald-600 px-5 py-3 text-white font-semibold hover:bg-emerald-700 transition"
                    >
                      <Save size={18} />
                      Save Changes
                    </button>
                  </div>
                )}
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  )
}

export default EditCategory