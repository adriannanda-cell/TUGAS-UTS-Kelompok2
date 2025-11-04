// Products Data
const products = [
    {
        id: "1",
        name: "ASUS ROG Strix G15",
        category: "laptop",
        price: 18500000,
        image: "https://images.unsplash.com/photo-1603302576837-37561b2e2302?w=500",
        specs: ["Intel i7-12700H", "RTX 3060", "16GB RAM", "512GB SSD"],
        stock: 5,
        rating: 4.8
    },
    {
        id: "2",
        name: "MacBook Air M2",
        category: "laptop",
        price: 19999000,
        image: "https://images.unsplash.com/photo-1517336714731-489689fd1ca8?w=500",
        specs: ["Apple M2", "8GB RAM", "256GB SSD", "13.6 inch"],
        stock: 8,
        rating: 4.9
    },
    {
        id: "3",
        name: "Dell XPS 13",
        category: "laptop",
        price: 16500000,
        image: "https://images.unsplash.com/photo-1593642632823-8f785ba67e45?w=500",
        specs: ["Intel i5-1240P", "16GB RAM", "512GB SSD", "13.4 inch"],
        stock: 3,
        rating: 4.7
    },
    {
        id: "4",
        name: "Custom Gaming PC",
        category: "desktop",
        price: 25000000,
        image: "https://images.unsplash.com/photo-1587202372634-32705e3bf49c?w=500",
        specs: ["Intel i9-13900K", "RTX 4080", "32GB RAM", "1TB NVMe"],
        stock: 2,
        rating: 5.0
    },
    {
        id: "5",
        name: "iMac 24-inch",
        category: "desktop",
        price: 22000000,
        image: "https://images.unsplash.com/photo-1517694712202-14dd9538aa97?w=500",
        specs: ["Apple M1", "8GB RAM", "256GB SSD", "4.5K Display"],
        stock: 4,
        rating: 4.8
    },
    {
        id: "6",
        name: "NVIDIA RTX 4070",
        category: "component",
        price: 9500000,
        image: "https://images.unsplash.com/photo-1591488320449-011701bb6704?w=500",
        specs: ["12GB GDDR6X", "DLSS 3", "Ray Tracing", "PCIe 4.0"],
        stock: 10,
        rating: 4.9
    },
    {
        id: "7",
        name: "AMD Ryzen 9 7950X",
        category: "component",
        price: 8500000,
        image: "https://images.unsplash.com/photo-1555617981-dac3880eac6e?w=500",
        specs: ["16 Cores", "32 Threads", "5.7GHz Boost", "AM5 Socket"],
        stock: 7,
        rating: 4.8
    },
    {
        id: "8",
        name: "Corsair Vengeance 32GB",
        category: "component",
        price: 2500000,
        image: "https://images.unsplash.com/photo-1541799948-b7bb8e99ebc8?w=500",
        specs: ["DDR5-6000", "32GB (2x16GB)", "RGB", "Low Latency"],
        stock: 15,
        rating: 4.7
    },
    {
        id: "9",
        name: "Logitech MX Master 3S",
        category: "accessory",
        price: 1500000,
        image: "https://images.unsplash.com/photo-1527864550417-7fd91fc51a46?w=500",
        specs: ["8K DPI", "Wireless", "USB-C", "Multi-device"],
        stock: 20,
        rating: 4.9
    },
    {
        id: "10",
        name: "Keychron K2 Mechanical",
        category: "accessory",
        price: 1200000,
        image: "https://images.unsplash.com/photo-1587829741301-dc798b83add3?w=500",
        specs: ["Mechanical", "Bluetooth", "RGB Backlit", "Hot-swappable"],
        stock: 12,
        rating: 4.8
    },
    {
        id: "11",
        name: "Samsung Odyssey G7",
        category: "accessory",
        price: 7500000,
        image: "https://images.unsplash.com/photo-1527443224154-c4a3942d3acf?w=500",
        specs: ["27 inch", "240Hz", "1440p", "Curved"],
        stock: 6,
        rating: 4.9
    },
    {
        id: "12",
        name: "Samsung 980 PRO 2TB",
        category: "component",
        price: 4500000,
        image: "https://images.unsplash.com/photo-1597872200969-2b65d56bd16b?w=500",
        specs: ["2TB NVMe", "PCIe 4.0", "7000MB/s Read", "5000MB/s Write"],
        stock: 18,
        rating: 4.8
    }
];

const categories = [
    { id: "all", name: "Semua Produk" },
    { id: "laptop", name: "Laptop" },
    { id: "desktop", name: "Desktop" },
    { id: "component", name: "Komponen" },
    { id: "accessory", name: "Aksesoris" }
];

// State
let cart = [];
let selectedCategory = "all";
let searchQuery = "";

// Format currency
function formatPrice(price) {
    return new Intl.NumberFormat("id-ID", {
        style: "currency",
        currency: "IDR",
        minimumFractionDigits: 0
    }).format(price);
}

// Show toast
function showToast(message, isError = false) {
    const toast = document.getElementById("toast");
    toast.textContent = message;
    toast.className = "toast show" + (isError ? " error" : "");
    setTimeout(() => {
        toast.className = "toast";
    }, 3000);
}

// Update cart badge
function updateCartBadge() {
    const badge = document.getElementById("cartBadge");
    const count = cart.reduce((sum, item) => sum + item.quantity, 0);
    if (count > 0) {
        badge.textContent = count;
        badge.style.display = "flex";
    } else {
        badge.style.display = "none";
    }
}

// Render categories
function renderCategories() {
    const container = document.getElementById("categoryButtons");
    container.innerHTML = categories.map(cat => `
        <button class="category-btn ${selectedCategory === cat.id ? 'active' : ''}" 
                onclick="selectCategory('${cat.id}')">
            ${cat.name}
        </button>
    `).join('');
}

// Select category
function selectCategory(categoryId) {
    selectedCategory = categoryId;
    renderCategories();
    renderProducts();
}

// Filter products
function getFilteredProducts() {
    return products.filter(product => {
        const matchesCategory = selectedCategory === "all" || product.category === selectedCategory;
        const matchesSearch = product.name.toLowerCase().includes(searchQuery.toLowerCase()) ||
                            product.specs.some(spec => spec.toLowerCase().includes(searchQuery.toLowerCase()));
        return matchesCategory && matchesSearch;
    });
}

// Render products
function renderProducts() {
    const grid = document.getElementById("productsGrid");
    const emptyState = document.getElementById("emptyState");
    const filtered = getFilteredProducts();

    if (filtered.length === 0) {
        grid.style.display = "none";
        emptyState.style.display = "block";
        return;
    }

    grid.style.display = "grid";
    emptyState.style.display = "none";

    grid.innerHTML = filtered.map(product => `
        <div class="product-card">
            <div class="product-image">
                <img src="${product.image}" alt="${product.name}" onerror="this.src='https://via.placeholder.com/400?text=No+Image'">
                ${product.stock < 5 && product.stock > 0 ? '<div class="stock-badge limited">Stok Terbatas</div>' : ''}
                ${product.stock === 0 ? '<div class="stock-badge out">Habis</div>' : ''}
            </div>
            <div class="product-content">
                <h3 class="product-name">${product.name}</h3>
                <div class="product-rating">
                    <span class="star">★</span>
                    <span>${product.rating}</span>
                    <span style="color: #6b7280; margin-left: 0.25rem;">(${product.stock} stok)</span>
                </div>
                <div class="product-specs">
                    ${product.specs.slice(0, 2).map(spec => `
                        <div class="spec-item">
                            <span>📦</span>
                            <span>${spec}</span>
                        </div>
                    `).join('')}
                </div>
                <div class="product-price">${formatPrice(product.price)}</div>
                <button class="add-to-cart-btn" 
                        onclick="addToCart('${product.id}')"
                        ${product.stock === 0 ? 'disabled' : ''}>
                    <svg width="16" height="16" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M3 3h2l.4 2M7 13h10l4-8H5.4M7 13L5.4 5M7 13l-2.293 2.293c-.63.63-.184 1.707.707 1.707H17m0 0a2 2 0 100 4 2 2 0 000-4zm-8 2a2 2 0 11-4 0 2 2 0 014 0z"/>
                    </svg>
                    ${product.stock === 0 ? 'Stok Habis' : 'Tambah ke Keranjang'}
                </button>
            </div>
        </div>
    `).join('');
}

// Add to cart
function addToCart(productId) {
    const product = products.find(p => p.id === productId);
    const existing = cart.find(item => item.id === productId);

    if (existing) {
        if (existing.quantity >= product.stock) {
            showToast("Stok tidak mencukupi", true);
            return;
        }
        existing.quantity++;
        showToast("Jumlah produk diperbarui");
    } else {
        cart.push({ ...product, quantity: 1 });
        showToast("Produk ditambahkan ke keranjang");
    }

    updateCartBadge();
    renderCart();
}

// Update quantity
function updateQuantity(productId, delta) {
    const item = cart.find(i => i.id === productId);
    const product = products.find(p => p.id === productId);
    
    if (item) {
        const newQuantity = item.quantity + delta;
        if (newQuantity < 1) return;
        if (newQuantity > product.stock) {
            showToast("Stok tidak mencukupi", true);
            return;
        }
        item.quantity = newQuantity;
        updateCartBadge();
        renderCart();
    }
}

// Remove from cart
function removeFromCart(productId) {
    cart = cart.filter(item => item.id !== productId);
    updateCartBadge();
    renderCart();
    showToast("Produk dihapus dari keranjang");
}

// Render cart
function renderCart() {
    const cartItems = document.getElementById("cartItems");
    const cartFooter = document.getElementById("cartFooter");

    if (cart.length === 0) {
        cartItems.innerHTML = `
            <div class="cart-empty">
                <svg width="64" height="64" fill="none" stroke="currentColor" viewBox="0 0 24 24" style="color: #d1d5db; margin-bottom: 1rem;">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M16 11V7a4 4 0 00-8 0v4M5 9h14l1 12H4L5 9z"/>
                </svg>
                <p>Keranjang belanja Anda kosong</p>
            </div>
        `;
        cartFooter.innerHTML = '';
        return;
    }

    cartItems.innerHTML = cart.map(item => `
        <div class="cart-item">
            <div class="cart-item-image">
                <img src="${item.image}" alt="${item.name}" onerror="this.src='https://via.placeholder.com/80?text=No+Image'">
            </div>
            <div class="cart-item-details">
                <div class="cart-item-name">${item.name}</div>
                <div class="cart-item-price">${formatPrice(item.price)}</div>
                <div class="cart-item-controls">
                    <button class="quantity-btn" onclick="updateQuantity('${item.id}', -1)">
                        <svg width="12" height="12" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M20 12H4"/>
                        </svg>
                    </button>
                    <span class="quantity">${item.quantity}</span>
                    <button class="quantity-btn" onclick="updateQuantity('${item.id}', 1)" 
                            ${item.quantity >= item.stock ? 'disabled' : ''}>
                        <svg width="12" height="12" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 4v16m8-8H4"/>
                        </svg>
                    </button>
                    <button class="remove-btn" onclick="removeFromCart('${item.id}')">
                        <svg width="16" height="16" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M19 7l-.867 12.142A2 2 0 0116.138 21H7.862a2 2 0 01-1.995-1.858L5 7m5 4v6m4-6v6m1-10V4a1 1 0 00-1-1h-4a1 1 0 00-1 1v3M4 7h16"/>
                        </svg>
                    </button>
                </div>
            </div>
        </div>
    `).join('');

    const total = cart.reduce((sum, item) => sum + (item.price * item.quantity), 0);

    cartFooter.innerHTML = `
        <div class="cart-total">
            <span style="color: #6b7280;">Subtotal</span>
            <span>${formatPrice(total)}</span>
        </div>
        <div class="cart-total final">
            <span>Total</span>
            <span class="amount">${formatPrice(total)}</span>
        </div>
        <button class="checkout-btn" onclick="checkout()">Checkout</button>
    `;
}

// Checkout
function checkout() {
    alert("Fitur checkout akan segera hadir!");
}

// Toggle cart
function toggleCart(show) {
    const overlay = document.getElementById("cartOverlay");
    const sidebar = document.getElementById("cartSidebar");
    
    if (show) {
        overlay.classList.add("active");
        sidebar.classList.add("active");
        renderCart();
    } else {
        overlay.classList.remove("active");
        sidebar.classList.remove("active");
    }
}

// Event listeners
document.addEventListener("DOMContentLoaded", function() {
    document.getElementById("cartButton").addEventListener("click", () => toggleCart(true));
    document.getElementById("closeCart").addEventListener("click", () => toggleCart(false));
    document.getElementById("cartOverlay").addEventListener("click", () => toggleCart(false));
    
    document.getElementById("searchInput").addEventListener("input", (e) => {
        searchQuery = e.target.value;
        renderProducts();
    });

    // Initialize
    renderCategories();
    renderProducts();
});
