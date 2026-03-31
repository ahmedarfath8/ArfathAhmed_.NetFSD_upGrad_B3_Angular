function renderCheckoutSummary() {
  const cart = getCart();

  if (cart.length === 0) {
    $("#checkoutSummary").html("<p>Your cart is empty.</p>");
    return;
  }

  let summaryHtml = "<ul class='list-group list-group-flush'>";
  let total = 0;

  cart.forEach(function(item) {
    const subtotal = item.price * item.quantity;
    total += subtotal;

    summaryHtml += `
      <li class="list-group-item d-flex justify-content-between">
        <span>${item.name} x ${item.quantity}</span>
        <span>Rs. ${subtotal}</span>
      </li>
    `;
  });

  summaryHtml += `
      <li class="list-group-item d-flex justify-content-between fw-bold">
        <span>Total</span>
        <span>Rs. ${total}</span>
      </li>
    </ul>
  `;

  $("#checkoutSummary").html(summaryHtml);
}

$(document).ready(function() {
  renderCheckoutSummary();
});

$("#checkoutForm").on("submit", function(event) {
  event.preventDefault();

  const cart = getCart();
  const customerName = $("#customerName").val().trim();
  const customerPhone = $("#customerPhone").val().trim();
  const customerEmail = $("#customerEmail").val().trim();
  const customerAddress = $("#customerAddress").val().trim();
  const customerCity = $("#customerCity").val().trim();
  const customerState = $("#customerState").val().trim();
  const customerPincode = $("#customerPincode").val().trim();
  const paymentMethod = $("#paymentMethod").val();

  if (cart.length === 0) {
    alert("Your cart is empty.");
    return;
  }

  if (!customerName || !customerPhone || !customerEmail || !customerAddress || !customerCity || !customerState || !customerPincode || !paymentMethod) {
    alert("Please fill in all checkout details.");
    return;
  }

  alert("Order placed successfully for " + customerName + " via " + paymentMethod + ".");
  localStorage.removeItem("cart");
  window.location.href = "index.html";
});
