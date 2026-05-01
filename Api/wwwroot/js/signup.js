
document.addEventListener("DOMContentLoaded", () => {
    const form = document.getElementById("signupForm");
    const msgBox = document.getElementById("signupMessage");

    if (!form) return;

    function showMessage(text, type = "error") {
        if (!msgBox) return;
        msgBox.textContent = text || "";
        msgBox.style.margin = text ? "0 0 10px" : "0";
        msgBox.style.fontSize = "0.9rem";
        msgBox.style.color = (type === "success") ? "#15803d" : "#b91c1c";
    }

    form.addEventListener("submit", async (e) => {
        e.preventDefault();
        showMessage("");

        const email = document.getElementById("email")?.value.trim();
        const firstName = document.getElementById("firstName")?.value.trim();
        const lastName = document.getElementById("lastName")?.value.trim();
        const password = document.getElementById("password")?.value;
        const confirmPassword = document.getElementById("confirmPassword")?.value;

        if (!email || !firstName || !lastName || !password || !confirmPassword) {
            showMessage("Please fill in all fields.");
            return;
        }

        if (password !== confirmPassword) {
            showMessage("Password and confirmation do not match.");
            return;
        }

        const user = {
            FirstName: firstName,
            LastName: lastName,
            Email: email,
            Password: password
        };

        try {
            try {
                const usersResp = await fetch("/api/Users/GetUsers");
                if (usersResp.ok) {
                    const users = await usersResp.json();
                    const lower = email.toLowerCase();
                    const exists = Array.isArray(users) &&
                        users.some(u => (u.email || u.Email || "").toLowerCase() === lower);

                    if (exists) {
                        await uiAlert("This email address is already registered.", "Email already exists", "error");
                        return;
                    }
                }
            } catch {
            }

            showMessage("Creating your account...", "success");

            const response = await fetch("/api/Users/AddUser", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(user)
            });

            if (!response.ok) {
                let data = null;
                try { data = await response.json(); } catch { }

                if (data && Array.isArray(data.errors) && data.errors.length > 0) {
                    const firstErr = data.errors[0];
                    showMessage(firstErr.error || "Validation failed.");
                } else if (data && data.message) {
                    showMessage(data.message);
                } else {
                    window.location.href = "login.html";
                }
                return;
            }


        } catch (err) {
            console.error(err);
            showMessage("A network error occurred. Please try again.");
        }
    });
});
function uiModal({
    title = "Info",
    body = "",
    variant = "default", 
    buttons = [{ text: "OK", value: true, className: "primary" }]
}) {
    const modal = document.getElementById("appModal");
    const titleEl = document.getElementById("appModalTitle");
    const bodyEl = document.getElementById("appModalBody");
    const actionsEl = document.getElementById("appModalActions");

    if (!modal || !titleEl || !bodyEl || !actionsEl) {
        console.warn("Modal DOM not found. Message:", title, body);
        return Promise.resolve(true);
    }

    let resolve;
    const p = new Promise(r => (resolve = r));

    modal.classList.remove("modal-default", "modal-error", "modal-success", "modal-warning");
    modal.classList.add(`modal-${variant}`);

    const onKey = (e) => {
        if (e.key === "Escape") close(false);
    };

    const close = (val) => {
        modal.classList.add("hidden");
        modal.setAttribute("aria-hidden", "true");
        document.removeEventListener("keydown", onKey);
        resolve(val);
    };

    titleEl.textContent = title;
    bodyEl.textContent = body;
    actionsEl.innerHTML = "";

    modal.classList.remove("hidden");
    modal.setAttribute("aria-hidden", "false");

    document.addEventListener("keydown", onKey);

    modal.querySelectorAll("[data-close='1']").forEach(el => {
        el.onclick = () => close(false);
    });

    buttons.forEach(b => {
        const btn = document.createElement("button");
        btn.type = "button";
        btn.className = `modal-btn ${b.className || ""}`.trim();
        btn.textContent = b.text || "OK";
        btn.onclick = () => close(b.value);
        actionsEl.appendChild(btn);
    });

    setTimeout(() => actionsEl.querySelector("button")?.focus(), 0);

    return p;
}

function uiAlert(message, title = "Info", variant = "default") {
    return uiModal({
        title,
        body: message,
        variant,
        buttons: [{ text: "OK", value: true, className: "primary" }]
    });
}

function uiConfirm(message, title = "Confirm") {
    return uiModal({
        title,
        body: message,
        variant: "error",
        buttons: [
            { text: "Cancel", value: false },
            { text: "Delete", value: true, className: "danger" }
        ]
    });
}
