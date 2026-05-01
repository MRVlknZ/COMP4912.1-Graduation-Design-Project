
const COLOR_NAME_MAP = {
    101: "Red",
    102: "Blue",
    103: "Green",
    104: "Yellow",
    105: "Orange",
    106: "Purple",
    107: "Pink",
    108: "Turquoise",
    109: "Navy",
    110: "SkyBlue",
    111: "RoyalBlue",
    112: "MidnightBlue",
    113: "Emerald",
    114: "Mint",
    115: "ForestGreen",
    116: "Olive",
    117: "Lavender",
    118: "Magenta",
    119: "Amethyst",
    120: "Orchid",
    121: "Salmon",
    122: "Coral",
    123: "Peach",
    124: "Apricot",
    125: "Gold",
    126: "Amber",
    127: "Mustard",
    128: "HoneyYellow",
    129: "Silver",
    130: "Titanium",
    131: "SlateGray",
    132: "LightGray"
};


const DRILL_TYPE_CONFIG = {
    color: {
        type: "color",
        buildListUrl: (userId) => `/api/CColorDrill/GetByUser?userId=${userId}`,
        buildPlayUrl: (id) => `/color-drill.html?id=${id}`,
        buildDeleteUrl: (id) => `/api/CColorDrill/SoftDelete?id=${id}`,
        defaultName: "Custom Color Drill"
    },
    text: {
        type: "text",
        buildListUrl: (userId) => `/api/CTextDrill/GetByUser?userId=${userId}`,
        buildPlayUrl: (id) => `/c-text-drill.html?id=${id}`,
        buildDeleteUrl: (id) => `/api/CTextDrill/SoftDelete?id=${id}`,
        defaultName: "Custom Text Drill"
    },
    comb: {
        type: "comb",
        buildListUrl: (userId) => `/api/CCombDrill/GetByUser?userId=${userId}`,
        buildPlayUrl: (id) => `/c-comb-drill.html?id=${id}`,
        buildDeleteUrl: (id) => `/api/CCombDrill/SoftDelete?id=${id}`,
        defaultName: "Custom Combination Drill"
    },
    focus: {
        type: "focus",
        buildListUrl: (userId) => `/api/CFocusDrill/GetByUser?userId=${userId}`,
        buildPlayUrl: (id) => `/c-focus-drill.html?id=${id}`,
        buildDeleteUrl: (id) => `/api/CFocusDrill/SoftDelete?id=${id}`,
        defaultName: "Custom Focus Drill"
    },
    sound: {
        type: "sound",
        buildListUrl: (userId) => `/api/CSoundDrill/GetByUser?userId=${userId}`,
        buildPlayUrl: (id) => `/c-sound-drill.html?id=${id}`,
        buildDeleteUrl: (id) => `/api/CSoundDrill/SoftDelete?id=${id}`,
        defaultName: "Custom Sound Drill"
    }


};

function getProp(obj, lower, upper, fallback = "") {
    return obj?.[lower] ?? obj?.[upper] ?? fallback;
}

function escapeHtml(str = "") {
    return String(str).replace(/[&<>"']/g, ch => ({
        "&": "&amp;",
        "<": "&lt;",
        ">": "&gt;",
        '"': "&quot;",
        "'": "&#39;"
    }[ch] || ch));
}

document.addEventListener("DOMContentLoaded", () => {

    const stored = localStorage.getItem("currentUser");
    if (!stored) {
        window.location.href = "login.html";
        return;
    }

    let currentUser;
    try {
        currentUser = JSON.parse(stored);
    } catch (e) {
        console.error("currentUser parse error", e);
        localStorage.removeItem("currentUser");
        window.location.href = "login.html";
        return;
    }

    const profileBtn = document.getElementById("profileBtn");
    const settingsBtn = document.getElementById("settingsBtn");
    const logoutBtn = document.getElementById("logoutBtn");
    const start4ColorBtn = document.getElementById("start4Color");
    const startPreTxtBtn = document.getElementById("startPreText");
    const startCustomColorBtn = document.getElementById("startCustomColor");
    const startCustomTextBtn = document.getElementById("startCustomTextDrill");
    const startPreCombBtn = document.getElementById("startPreComb");
    const startCustomCombBtn = document.getElementById("startCustomComb");
    const startPreFocusBtn = document.getElementById("startPreFocus");
    const startPreSoundBtn = document.getElementById("startPreSound");
    const startCustomFocusBtn = document.getElementById("startCustomFocusDrill");
    const startCustomSoundBtn = document.getElementById("startCustomSoundDrill");



    logoutBtn?.addEventListener("click", () => {
        localStorage.removeItem("currentUser");
        window.location.href = "login.html";
    });

    start4ColorBtn?.addEventListener("click", () => {
        window.location.href = "Pre-4color-drill.html";
    });

    startPreTxtBtn?.addEventListener("click", () => {
        window.location.href = "Pre-text-drill.html";
    });

    startCustomColorBtn?.addEventListener("click", () => {
        window.location.href = "Custom-color-drill.html";
    });

    startCustomTextBtn?.addEventListener("click", () => {
        window.location.href = "Custom-text-drill.html";
    });
    startPreCombBtn?.addEventListener("click", () => {
        window.location.href = "Pre-comb-drill.html";
    });

    startCustomCombBtn?.addEventListener("click", () => {
        window.location.href = "Custom-comb-drill.html";
    });
    startPreFocusBtn?.addEventListener("click", () => {
        window.location.href = "Pre-focus-drill.html";
    });

    startPreSoundBtn?.addEventListener("click", () => {
        window.location.href = "Pre-sound-drill.html";
    });
    startPreExjumpBtn?.addEventListener("click", () => {
        window.location.href = "Pre-exjump-drill.html";
    });
    startPreLineDrillBtn?.addEventListener("click", () => {
        window.location.href = "Pre-line-drill.html";
    });

    startCustomFocusBtn?.addEventListener("click", () => {
        window.location.href = "Custom-focus-drill.html";
    });

    startCustomSoundBtn?.addEventListener("click", () => {
        window.location.href = "Custom-sound-drill.html";
    });
    quickFeetStartC?.addEventListener("click", () => {
        window.location.href = "QuickFeet-Challenge.html";
    });
    ExJumpStartC?.addEventListener("click", () => {
        window.location.href = "ExpJump-Challenge.html";
    });
    startClickC?.addEventListener("click", () => {
        window.location.href = "Click-Challenge.html";
    });
    



    profileBtn?.addEventListener("click", async () => {
        const fullName = `${currentUser.firstName || "-"} ${currentUser.lastName || "-"}`.trim();
        const email = currentUser.email || "-";
        const createdRaw = currentUser.createdAt || currentUser.CreatedAt;

        const createdAt = createdRaw
            ? new Date(createdRaw).toLocaleDateString("tr-TR", {
                year: "numeric",
                month: "short",
                day: "numeric"
            })
            : "-";

        const body = `
      <div class="profile-modal">
        <div class="profile-main">
          <div class="profile-name">${escapeHtml(fullName)}</div>
        </div>

        <div class="profile-grid">
          <div class="profile-item">
            <span class="profile-label">Email</span>
            <span class="profile-value">${escapeHtml(email)}</span>
          </div>
          <div class="profile-item">
            <span class="profile-label">Created At</span>
            <span class="profile-value">${escapeHtml(createdAt)}</span>
          </div>
        </div>
      </div>
    `;

        uiModal({
            title: "Profile",
            body,
            buttons: [{ text: "Close", value: true, className: "primary" }]
        });
    });


    settingsBtn?.addEventListener("click",async () => {
        await uiAlert("Settings page will be here.", "Settings");
    });


    refreshUserFromApi(currentUser).then((updated) => {
        if (updated) currentUser = updated;

        const userId = currentUser.id ?? currentUser.Id ?? 0;
        if (!userId) {
            window.location.href = "login.html";
            return;
        }

        initCustomDrills(userId);
    });
});


async function refreshUserFromApi(currentUser) {
    try {
        const resp = await fetch("/api/Users/GetUsers");
        if (!resp.ok) {
            console.warn("GetUsers error", resp.status);
            return null;
        }

        const users = await resp.json();
        let apiUser = null;

        if (currentUser.id) {
            apiUser = users.find(u => (u.id || u.Id) === currentUser.id);
        }

        if (!apiUser && currentUser.email) {
            const lower = currentUser.email.toLowerCase();
            apiUser = users.find(
                u => (u.email || u.Email || "").toLowerCase() === lower
            );
        }

        if (apiUser) {
            const updated = {
                id: apiUser.id || apiUser.Id,
                firstName: apiUser.firstName || apiUser.FirstName,
                lastName: apiUser.lastName || apiUser.LastName,
                email: apiUser.email || apiUser.Email,
                createdAt: apiUser.createdAt || apiUser.CreatedAt
            };
            localStorage.setItem("currentUser", JSON.stringify(updated));
            return updated;
        }

        return null;
    } catch (err) {
        console.error("refreshUserFromApi error", err);
        return null;
    }
}


function initCustomDrills(userId) {
    const filterSelect = document.getElementById("customDrillFilter");
    if (!filterSelect) return;

    const initialType = filterSelect.value || "color";
    loadCustomDrills(userId, initialType);

    filterSelect.addEventListener("change", () => {
        loadCustomDrills(userId, filterSelect.value);
    });
}

async function loadCustomDrills(userId, type = "color") {
    const container = document.getElementById("customDrillsList");
    const emptyMsg = document.getElementById("noCustomDrills");
    if (!container || !emptyMsg) return;

    container.innerHTML = "";
    emptyMsg.style.display = "none";

    const cfg = DRILL_TYPE_CONFIG[type] || DRILL_TYPE_CONFIG["color"];

    try {
        const res = await fetch(cfg.buildListUrl(userId));
        if (!res.ok) {
            console.warn("loadCustomDrills error status:", res.status);
            emptyMsg.style.display = "block";
            return;
        }

        const drills = await res.json();
        console.log(`User's custom ${cfg.type} drills:`, drills);

        if (!Array.isArray(drills) || drills.length === 0) {
            emptyMsg.style.display = "block";
            return;
        }

        const active = drills.filter(d => {
            const del = d.deletedAt ?? d.DeletedAt;
            return del === null || del === undefined;
        });

        if (!active.length) {
            emptyMsg.style.display = "block";
            return;
        }

        active.sort((a, b) => {
            const aid = Number(a.id ?? a.Id ?? 0);
            const bid = Number(b.id ?? b.Id ?? 0);
            return bid - aid;
        });

        active.forEach(d => {
            const id = d.id ?? d.Id;
            const fullName = d.name ?? d.Name ?? cfg.defaultName;
            const shortName = fullName.length > 18
                ? fullName.slice(0, 16) + "…"
                : fullName;

            const card = document.createElement("div");
            card.className = "drill-box";

            card.innerHTML = `
  <div class="drill-box-header">
   <div class="drill-box-tools vertical">
      <button class="icon-small info-btn" title="View drill summary">
        <i class='bx bx-help-circle'></i>
      </button>
      <button class="icon-small delete-btn" title="Delete drill">
        <i class='bx bx-trash'></i>
      </button>
    </div>
    <h3 class="ellipsis" data-full="${escapeHtml(fullName)}">
      <span class="ellipsis-text">${escapeHtml(shortName)}</span>
    </h3>
  </div>

  <button class="start-btn" data-id="${id}">Start Drill</button>
`;


            const startBtn = card.querySelector(".start-btn");
            startBtn?.addEventListener("click", () => {
                window.location.href = cfg.buildPlayUrl(id);
            });

            const infoBtn = card.querySelector(".info-btn");
            infoBtn?.addEventListener("click", () => {
                showDrillSummary(d, cfg.type);
            });

            const deleteBtn = card.querySelector(".delete-btn");
            deleteBtn.addEventListener("click", async (ev) => {
                ev.stopPropagation();
                ev.preventDefault();

                const ok = await uiConfirm("Are you sure you want to delete this drill?", "Delete Drill");
                if (!ok) return;

                try {
                    const delRes = await fetch(cfg.buildDeleteUrl(id), { method: "POST" });
                    const raw = await delRes.text();
                    console.log("SoftDelete response:", delRes.status, raw);
                    await loadCustomDrills(userId, type);
                } catch (err) {
                    console.error("SoftDelete error:", err);
                    await uiAlert("Unexpected error while deleting drill.", "Error");
                }
            });


            container.appendChild(card);

        });
        requestAnimationFrame(() => applyEllipsisTooltips());

    } catch (err) {
        console.error("loadCustomDrills exception:", err);
        emptyMsg.style.display = "block";
    }
}

function showDrillSummary(drill, type) {
    const cfg = DRILL_TYPE_CONFIG[type] || DRILL_TYPE_CONFIG["color"];

    const name = getProp(drill, "name", "Name", cfg.defaultName);
    const desc = getProp(drill, "description", "Description", "-");

    let msg = `Drill name: ${name}\nDescription: ${desc}\n`;

    if (type === "color") {
        const total = Number(getProp(drill, "totalDurationSec", "TotalDurationSec", 0)) || 0;
        const colorCount = Number(getProp(drill, "colorCount", "ColorCount", 0)) || 0;
        const switchInterval = Number(getProp(drill, "switchIntervalSec", "SwitchIntervalSec", 0)) || 0;
        const isRandom = !!(drill.isRandomOrder ?? drill.IsRandomOrder);
        const difficulty = getProp(drill, "difficultyLevel", "DifficultyLevel", "-");

        const selectedColorIdsStr = getProp(drill, "selectedColorIds", "SelectedColorIds", "");
        const selectedColorNames = selectedColorIdsStr
            .split(",")
            .map(x => x.trim())
            .filter(Boolean)
            .map(idStr => {
                const idNum = Number(idStr);
                return COLOR_NAME_MAP[idNum] || idStr;
            });

        const actionsPerColorStr = getProp(drill, "actionsPerColor", "ActionsPerColor", "");

        msg += `\nTotal duration: ${total} sec`;
        msg += `\nColor count: ${colorCount}`;
        msg += `\nSwitch interval: ${switchInterval} sec`;
        msg += `\nRandom order: ${isRandom ? "Yes" : "No"}`;
        msg += `\nDifficulty: ${difficulty}`;

        if (selectedColorNames.length) {
            msg += `\nColors: ${selectedColorNames.join(", ")}`;
        }

        const actionsPreview = actionsPerColorStr
            .split(";")
            .map(s => s.trim())
            .filter(Boolean)
            .map(pair => {
                const [colorIdRaw, actionRaw] = pair.split(":");
                const colorId = (colorIdRaw || "").replace(/[^\d]/g, "");
                const colorName = COLOR_NAME_MAP[Number(colorId)] || (colorIdRaw || "").trim();

                const cssColor = (colorName || "").toLowerCase();
                const action = (actionRaw || "").trim();

                const swatch = `<span style="display:inline-block;width:10px;height:10px;border-radius:3px;background:${cssColor};border:1px solid rgba(255,255,255,.25);margin-right:8px;vertical-align:middle;"></span>`;

                return `${swatch}${escapeHtml(colorName)}: ${escapeHtml(action)}`;
            })
            .join("<br>");



        if (actionsPreview) {
            msg += `\n\nActions:\n${actionsPreview}`;
        }

    } else if (type === "text") {
        const total = Number(getProp(drill, "totalDurationSec", "TotalDurationSec", 0)) || 0;
        const exNamesStr = getProp(drill, "exNames", "ExNames", "");
        const exNames = exNamesStr.split(";").map(x => x.trim()).filter(Boolean);
        const exDurations = (drill.exDurationsSec || drill.ExDurationsSec || "")
            .split(";")
            .map(x => Number(x) || 0);
        const repeatCount = Number(getProp(drill, "repeatCount", "RepeatCount", 1)) || 1;
        const isSequential = !!(drill.isSequential ?? drill.IsSequential);
        const hasBreakExs = !!(drill.hasBreakBtwExs ?? drill.HasBreakBtwExs);
        const breakExsSec = Number(getProp(drill, "breakBtwExsSec", "BreakBtwExsSec", 0)) || 0;
        const hasBreakRep = !!(drill.hasBreakBtwRepeats ?? drill.HasBreakBtwRepeats);
        const breakRepSec = Number(getProp(drill, "breakBtwRepeatsSec", "BreakBtwRepeatsSec", 0)) || 0;

        msg += `\nTotal duration: ${total} sec`;
        msg += `\nTotal exercises: ${exNames.length}`;
        msg += `\nRepeat count: ${repeatCount}`;
        msg += `\nOrder: ${isSequential ? "Sequential" : "Random"}`;
        msg += `\nBreak between exercises: ${hasBreakExs ? breakExsSec + " sec" : "No"}`;
        msg += `\nBreak between repeats: ${hasBreakRep ? breakRepSec + " sec" : "No"}`;

        if (exNames.length) {
            msg += `\n\nExercises:`;

            exNames.slice(0, 5).forEach((n, i) => {
                const sec = exDurations[i] || 0;
                msg += `\n${i + 1}) ${n} – ${sec} sec`;
            });

            if (exNames.length > 5) msg += `\n...`;
        }

    }
    else if (type === "comb") {
        const total = Number(getProp(drill, "totalDurationSec", "TotalDurationSec", 0)) || 0;
        const cmdCount = Number(getProp(drill, "commandCount", "CommandCount", 0)) || 0;
        const cmdListRaw = getProp(drill, "commandList", "CommandList", "");

        const cpc = Number(getProp(drill, "commandsPerCombination", "CommandsPerCombination", 2)) || 2;
        const showSec = Number(getProp(drill, "combinationDisplaySec", "CombinationDisplaySec", 2)) || 2;
        const transSec = Number(getProp(drill, "transitionSec", "TransitionSec", 1)) || 1;
        const allowRep = !!(drill.allowRepetition ?? drill.AllowRepetition);
        const diff = getProp(drill, "difficultyLevel", "DifficultyLevel", "-");

        const cmds = (cmdListRaw || "").split(",").map(x => x.trim()).filter(Boolean);

        msg += `\nTotal duration: ${total} sec`;
        msg += `\nCommand count: ${cmdCount || cmds.length}`;
        msg += `\nCommands per combination: ${cpc}`;
        msg += `\nDisplay sec: ${showSec}`;
        msg += `\nTransition sec: ${transSec}`;
        msg += `\nAllow repetition: ${allowRep ? "Yes" : "No"}`;
        msg += `\nDifficulty: ${diff}`;

        if (cmds.length) {
            msg += `\n\nCommands:\n` + cmds.slice(0, 10).map((c, i) => `${i + 1}) ${c}`).join("\n");
            if (cmds.length > 10) msg += `\n...`;
        }
    }

    else if (type === "sound") {
        const total = Number(getProp(drill, "totalDurationSec", "TotalDurationSec", 0)) || 0;
        const interval = Number(getProp(drill, "commandIntervalSec", "CommandIntervalSec", 0)) || 0;
        const cmdCount = Number(getProp(drill, "voiceCommandCount", "VoiceCommandCount", 0)) || 0;
        const cmdListRaw = getProp(drill, "voiceCommandList", "VoiceCommandList", "");
        const diff = getProp(drill, "difficultyLevel", "DifficultyLevel", "-");
        const isRandom = !!(drill.isRandomOrder ?? drill.IsRandomOrder);

        const cmds = (cmdListRaw || "").split(",").map(x => x.trim()).filter(Boolean);

        msg += `\nTotal duration: ${total} sec`;
        msg += `\nCommand interval: ${interval} sec`;
        msg += `\nRandom order: ${isRandom ? "Yes" : "No"}`;
        msg += `\nDifficulty: ${diff}`;
        msg += `\nTotal commands: ${cmdCount || cmds.length}`;

        if (cmds.length) {
            msg += `\n\nCommands:\n` + cmds.slice(0, 12).map((c, i) => `${i + 1}) ${c}`).join("\n");
            if (cmds.length > 12) msg += `\n...`;
        }
    }

    else if (type === "focus") {
        const total = Number(getProp(drill, "totalDurationSec", "TotalDurationSec", 0)) || 0;
        const switchInterval = Number(getProp(drill, "switchIntervalSec", "SwitchIntervalSec", 0)) || 0;
        const targetColorCount = Number(getProp(drill, "targetColorCount", "TargetColorCount", 0)) || 0;

        const diff = getProp(drill, "difficultyLevel", "DifficultyLevel", "-");

        const targetColorsStr = getProp(drill, "targetColors", "TargetColors", "");
        const targetColorNames = targetColorsStr
            .split(",")
            .map(x => x.trim())
            .filter(Boolean)
            .map(idStr => COLOR_NAME_MAP[Number(idStr)] || idStr);

        const actionsStr = getProp(drill, "actionsForTargetColors", "ActionsForTargetColors", "");

        const autoInc = !!(drill.autoIncreaseDifficulty ?? drill.AutoIncreaseDifficulty);

        msg += `\nTotal duration: ${total} sec`;
        msg += `\nSwitch interval: ${switchInterval} sec`;
        msg += `\nTarget color count: ${targetColorCount}`;
        msg += `\nRandom order: ${autoInc ? "Yes" : "No"}`;
        msg += `\nDifficulty: ${diff}`;

        if (targetColorNames.length) {
            msg += `\nTargets: ${targetColorNames.join(", ")}`;
        }

        const preview = (actionsStr || "")
            .split(";")
            .map(s => s.trim())
            .filter(Boolean)
            .slice(0, 8)
            .map(pair => {
                const [colorId, action] = pair.split(":");
                const colorName = COLOR_NAME_MAP[Number(colorId)] || colorId;
                return `- ${colorName}: ${(action || "").trim()}`;
            })
            .join("\n");

        if (preview) msg += `\n\nActions:\n${preview}`;
    }





    uiModal({ title: "Drill Summary", body: msg, buttons: [{ text: "Close", value: true, className: "primary" }] });
}
function uiModal({ title = "Info", body = "", buttons = [{ text: "OK", value: true, className: "primary" }] }) {
    const modal = document.getElementById("appModal");
    const titleEl = document.getElementById("appModalTitle");
    const bodyEl = document.getElementById("appModalBody");
    const actionsEl = document.getElementById("appModalActions");
    if (!modal || !titleEl || !bodyEl || !actionsEl) {
        console.warn("Modal DOM not found. Message:", title, body);
        return Promise.resolve(true);
    }

    titleEl.textContent = title;
    bodyEl.innerHTML = body;
    actionsEl.innerHTML = "";

    modal.classList.remove("hidden");
    modal.setAttribute("aria-hidden", "false");

    const close = (val) => {
        modal.classList.add("hidden");
        modal.setAttribute("aria-hidden", "true");
        document.removeEventListener("keydown", onKey);
        resolve(val);
    };

    const onKey = (e) => {
        if (e.key === "Escape") close(false);
    };
    document.addEventListener("keydown", onKey);

    const closeTargets = modal.querySelectorAll("[data-close='1']");
    closeTargets.forEach(el => {
        el.onclick = () => close(false);
    });

    let resolve;
    const p = new Promise(r => (resolve = r));

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

function uiAlert(message, title = "Info") {
    return uiModal({
        title,
        body: message,
        buttons: [{ text: "OK", value: true, className: "primary" }]
    });
}

function uiConfirm(message, title = "Confirm") {
    return uiModal({
        title,
        body: message,
        buttons: [
            { text: "Cancel", value: false },
            { text: "Delete", value: true, className: "danger" }
        ]
    });
}
function applyEllipsisTooltips(root = document) {
    const titles = root.querySelectorAll("h3.ellipsis");

    titles.forEach(h3 => {
        const textEl = h3.querySelector(".ellipsis-text") || h3;
        const shown = (textEl.textContent || "").trim();
        const hasDots = shown.includes("…") || shown.endsWith("...");
        const isVisuallyEllipsized =
            Math.ceil(textEl.scrollWidth) > Math.ceil(textEl.clientWidth) + 1;

        const shouldShow = hasDots || isVisuallyEllipsized;

        h3.classList.toggle("has-ellipsis", shouldShow);

        
    });
}





document.addEventListener("DOMContentLoaded", () => {
    applyEllipsisTooltips();

    window.addEventListener("resize", () => {
        applyEllipsisTooltips();
    });
});