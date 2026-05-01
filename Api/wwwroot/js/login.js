
document.addEventListener("DOMContentLoaded", () => {
    const form = document.getElementById("loginForm");
    const msgBox = document.getElementById("loginMessage");

    if (!form) return;

    function showMessage(text, type = "error") {
        msgBox.textContent = text;
        msgBox.style.color = type === "success" ? "#22c55e" : "#f87171";
    }

    form.addEventListener("submit", async (e) => {
        e.preventDefault();
        showMessage("");

        const email = document.getElementById("email").value.trim();
        const password = document.getElementById("password").value;

        if (!email || !password) {
            showMessage("Please enter your email and password.");
            return;
        }

        try {
            const resp = await fetch("/api/Users/GetUsers");
            if (!resp.ok) {
                showMessage("Server error.");
                return;
            }

            const users = await resp.json();
            const lower = email.toLowerCase();

            const user = users.find(u =>
                (u.email || u.Email)?.toLowerCase() === lower &&
                (u.password || u.Password) === password
            );


            if (!user) {
                showMessage("Invalid email or password.");
                return;
            }
            const isActive = user.isActive ?? user.IsActive;
            const activeOk = (isActive === true) || (isActive === 1) || (isActive === "1");

            if (!activeOk) {
                showMessage("Your account is disabled. Please contact admin.");
                return;
            }

            localStorage.setItem("currentUser", JSON.stringify(user));
            showMessage("Login successful, redirecting...", "success");

            setTimeout(() => {
                window.location.href = "user.html";
            }, 600);

        } catch (err) {
            console.error(err);
            showMessage("Network error.");
        }
    });
});
