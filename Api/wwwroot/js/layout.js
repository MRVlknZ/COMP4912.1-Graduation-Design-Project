
document.addEventListener("DOMContentLoaded", function () {
    loadFragment("header.html", "site-header", true);
    loadFragment("footer.html", "site-footer", false);
});

document.addEventListener("DOMContentLoaded", function () {
    loadFragment("../partials/header.html", "site-header", true);
    loadFragment("../partials/footer.html", "site-footer", false);
});

function loadFragment(url, containerId, isHeader) {
    fetch(url)
        .then(function (response) {
            if (!response.ok) {
                throw new Error("HTTP error " + response.status);
            }
            return response.text();
        })
        .then(function (html) {
            var container = document.getElementById(containerId);
            if (!container) return;

            container.innerHTML = html;

            if (isHeader) {
                var exploreBtn = container.querySelector("#exploreBtn");
                if (exploreBtn) {
                    exploreBtn.addEventListener("click", function (e) {
                        var section = document.getElementById("pre-drills");
                        if (section) {
                            e.preventDefault();
                            section.scrollIntoView({ behavior: "smooth" });
                        }
                    });
                }

                var menuIcon = container.querySelector("#menuToggle");
                var sidebar = document.getElementById("sidebar");      
                var closeBtn = document.getElementById("sidebarClose");

                if (menuIcon && sidebar) {
                   
                    menuIcon.addEventListener("click", function () {
                        sidebar.classList.add("sidebar--open");
                    });

                  
                    if (closeBtn) {
                        closeBtn.addEventListener("click", function () {
                            sidebar.classList.remove("sidebar--open");
                        });
                    }

                    var sidebarBtn = sidebar.querySelector(".sidebar-btn");
                    if (sidebarBtn) {
                        sidebarBtn.addEventListener("click", function (e) {
                            var section = document.getElementById("pre-drills");
                            if (section) {
                                e.preventDefault();
                                sidebar.classList.remove("sidebar--open");
                                section.scrollIntoView({ behavior: "smooth" });
                            }
                        });
                    }
                }
            }
        })
        .catch(function (err) {
            console.error("Fragment load error:", url, err);
        });
}
