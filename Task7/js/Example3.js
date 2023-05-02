const loginForm = document.getElementById("login-form");

loginForm.addEventListener("submit", function(event) {
  event.preventDefault(); 

  const usernameInput = document.getElementById("username");
  const passwordInput = document.getElementById("password");
  const rememberMeInput = document.getElementById("remember-me");

  const username = usernameInput.value;
  const password = passwordInput.value;
  const rememberMe = rememberMeInput.checked;

  const users = [
    { username: "Ruslana", password: "07022005" },
    { username: "Maria", password: "12082005" },
    { username: "Artem", password: "22022006" }
    
  ];

  const user = users.find(user => user.username === username && user.password === password);

  if (user) {
    alert("Ви успішно авторизувалися!");
    if (rememberMe) {
      localStorage.setItem("loggedInUser", JSON.stringify(user));
    }
  } else {
    alert("Невірний логін або пароль");
  }
});