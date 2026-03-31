function calculateTotal(cart) {
  let total = 0;

  cart.forEach(function(item) {
    total += item.price * item.quantity;
  });

  return total;
}

function renderCart() {
  const cart = getCart();

  if (cart.length === 0) {
    $("#cartItems").html("<div class='alert alert-info'>Your cart is empty.</div>");
    $("#cartSummary").html("");
    return;
  }

  let cartHtml = `
    <div class="table-responsive">
      <table class="table table-bordered align-middle bg-white">
        <thead class="table-dark">
          <tr>
            <th>Product</th>
            <th>Price</th>
            <th>Quantity</th>
            <th>Subtotal</th>
            <th>Action</th>
          </tr>
        </thead>
        <tbody>
  `;

  cart.forEach(function(item) {
    cartHtml += `
      <tr>
        <td>
          <div class="d-flex align-items-center gap-3">
            <img src="${item.image}" alt="${item.name}" class="cart-image">
            <span>${item.name}</span>
          </div>
        </td>
        <td>Rs. ${item.price}</td>
        <td>
          <input type="number" class="form-control quantity-input" data-id="${item.id}" value="${item.quantity}" min="1" style="width: 90px;">
        </td>
        <td>Rs. ${item.price * item.quantity}</td>
        <td>
          <button class="btn btn-danger btn-sm remove-btn" data-id="${item.id}">Remove</button>
        </td>
      </tr>
    `;
  });

  cartHtml += `
        </tbody>
      </table>
    </div>
  `;

  $("#cartItems").html(cartHtml);
  $("#cartSummary").html(`
    <div class="card p-3 shadow-sm">
      <h4>Total: Rs. ${calculateTotal(cart)}</h4>
      <a href="checkout.html" class="btn btn-dark mt-2">Proceed to Checkout</a>
    </div>
  `);
}

function removeFromCart(productId) {
  const cart = getCart().filter(function(item) {
    return item.id !== productId;
  });

  saveCart(cart);
  updateCartCount();
  renderCart();
}

function updateQuantity(productId, quantity) {
  const cart = getCart();
  const item = cart.find(function(product) {
    return product.id === productId;
  });

  if (!item) {
    return;
  }

  item.quantity = quantity;
  saveCart(cart);
  updateCartCount();
  renderCart();
}

$(document).ready(function() {
  renderCart();
});

$(document).on("click", ".remove-btn", function() {
  const productId = Number($(this).data("id"));
  removeFromCart(productId);
});

$(document).on("change", ".quantity-input", function() {
  const productId = Number($(this).data("id"));
  const quantity = Number($(this).val());

  if (quantity < 1) {
    $(this).val(1);
    updateQuantity(productId, 1);
    return;
  }

  updateQuantity(productId, quantity);
});
