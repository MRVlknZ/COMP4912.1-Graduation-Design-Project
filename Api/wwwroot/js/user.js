const COLOR_NAME_MAP = {
    101: "Red", 102: "Blue", 103: "Green", 104: "Yellow",
    105: "Orange", 106: "Purple", 107: "Pink", 108: "Turquoise",
    109: "Navy", 110: "SkyBlue", 111: "RoyalBlue", 112: "MidnightBlue",
    113: "Emerald", 114: "Mint", 115: "ForestGreen", 116: "Olive",
    117: "Lavender", 118: "Magenta", 119: "Amethyst", 120: "Orchid",
    121: "Salmon", 122: "Coral", 123: "Peach", 124: "Apricot",
    125: "Gold", 126: "Amber", 127: "Mustard", 128: "HoneyYellow",
    129: "Silver", 130: "Titanium", 131: "SlateGray", 132: "LightGray"
};

const DRILL_TYPE_CONFIG = {
    color: {
        type: "color",
        buildListUrl: (userId) => `/api/CColorDrill/GetByUser?userId=${userId}`,
        buildPlayUrl: (id) => `/color-drill.html?id=${id}`,
        buildDeleteUrl: (id) => `/api/CColorDrill/SoftDelete?id=${id}`,
        buildUpdateUrl: () => `/api/CColorDrill/Update`,
        defaultName: "Custom Color Drill"
    },
    text: {
        type: "text",
        buildListUrl: (userId) => `/api/CTextDrill/GetByUser?userId=${userId}`,
        buildPlayUrl: (id) => `/c-text-drill.html?id=${id}`,
        buildDeleteUrl: (id) => `/api/CTextDrill/SoftDelete?id=${id}`,
        buildUpdateUrl: () => `/api/CTextDrill/Update`,
        defaultName: "Custom Text Drill"
    },
    comb: {
        type: "comb",
        buildListUrl: (userId) => `/api/CCombDrill/GetByUser?userId=${userId}`,
        buildPlayUrl: (id) => `/c-comb-drill.html?id=${id}`,
        buildDeleteUrl: (id) => `/api/CCombDrill/SoftDelete?id=${id}`,
        buildUpdateUrl: () => `/api/CCombDrill/Update`,
        defaultName: "Custom Combination Drill"
    },
    focus: {
        type: "focus",
        buildListUrl: (userId) => `/api/CFocusDrill/GetByUser?userId=${userId}`,
        buildPlayUrl: (id) => `/c-focus-drill.html?id=${id}`,
        buildDeleteUrl: (id) => `/api/CFocusDrill/SoftDelete?id=${id}`,
        buildUpdateUrl: () => `/api/CFocusDrill/Update`,
        defaultName: "Custom Focus Drill"
    },
    sound: {
        type: "sound",
        buildListUrl: (userId) => `/api/CSoundDrill/GetByUser?userId=${userId}`,
        buildPlayUrl: (id) => `/c-sound-drill.html?id=${id}`,
        buildDeleteUrl: (id) => `/api/CSoundDrill/SoftDelete?id=${id}`,
        buildUpdateUrl: () => `/api/CSoundDrill/Update`,
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
    } catch {
        localStorage.removeItem("currentUser");
        window.location.href = "login.html";
        return;
    }

    const profileBtn = document.getElementById("profileBtn");
    const settingsBtn = document.getElementById("settingsBtn");
    const logoutBtn = document.getElementById("logoutBtn");
    const scheduleBtn = document.getElementById("scheduleBtn");
    const dietBtn = document.getElementById("dietBtn");

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

    dietBtn?.addEventListener("click", () => {
        window.location.href = "diet-recommendation.html";
    });



    logoutBtn?.addEventListener("click", () => {
        localStorage.removeItem("currentUser");
        window.location.href = "login.html";
    });

    start4ColorBtn?.addEventListener("click", () => window.location.href = "Pre-4color-drill.html");
    startPreTxtBtn?.addEventListener("click", () => window.location.href = "Pre-text-drill.html");
    startCustomColorBtn?.addEventListener("click", () => window.location.href = "Custom-color-drill.html");
    startCustomTextBtn?.addEventListener("click", () => window.location.href = "Custom-text-drill.html");
    startPreCombBtn?.addEventListener("click", () => window.location.href = "Pre-comb-drill.html");
    startCustomCombBtn?.addEventListener("click", () => window.location.href = "Custom-comb-drill.html");
    startPreFocusBtn?.addEventListener("click", () => window.location.href = "Pre-focus-drill.html");
    startPreSoundBtn?.addEventListener("click", () => window.location.href = "Pre-sound-drill.html");
    startCustomFocusBtn?.addEventListener("click", () => window.location.href = "Custom-focus-drill.html");
    startCustomSoundBtn?.addEventListener("click", () => window.location.href = "Custom-sound-drill.html");

    document.getElementById("startPreExjumpBtn")?.addEventListener("click", () => {
        window.location.href = "Pre-exjump-drill.html";
    });

    document.getElementById("startPreLineDrillBtn")?.addEventListener("click", () => {
        window.location.href = "Pre-line-drill.html";
    });

    document.getElementById("quickFeetStartC")?.addEventListener("click", () => {
        window.location.href = "QuickFeet-Challenge.html";
    });

    document.getElementById("ExJumpStartC")?.addEventListener("click", () => {
        window.location.href = "ExpJump-Challenge.html";
    });

    document.getElementById("ReaClickStartC")?.addEventListener("click", () => {
        window.location.href = "Reaction-Challenge.html";
    });

    document.getElementById("startClickC")?.addEventListener("click", () => {
        window.location.href = "Click-Challenge.html";
    });
    document.getElementById("stanceDefenseStartC")?.addEventListener("click", () => {
        window.location.href = "Stance-Defense-Challenge.html";
    });

    scheduleBtn?.addEventListener("click", async () => {
        await openScheduleCalendarModal(currentUser);
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

    settingsBtn?.addEventListener("click", async () => {
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

        if (!resp.ok) return null;

        const users = await resp.json();
        let apiUser = null;

        if (currentUser.id) {
            apiUser = users.find(u => (u.id || u.Id) === currentUser.id);
        }

        if (!apiUser && currentUser.email) {
            const lower = currentUser.email.toLowerCase();
            apiUser = users.find(u => (u.email || u.Email || "").toLowerCase() === lower);
        }

        if (!apiUser) return null;

        const updated = {
            id: apiUser.id || apiUser.Id,
            firstName: apiUser.firstName || apiUser.FirstName,
            lastName: apiUser.lastName || apiUser.LastName,
            email: apiUser.email || apiUser.Email,
            createdAt: apiUser.createdAt || apiUser.CreatedAt
        };

        localStorage.setItem("currentUser", JSON.stringify(updated));
        return updated;

    } catch {
        return null;
    }
}

function initCustomDrills(userId) {
    const filterSelect = document.getElementById("customDrillFilter");
    if (!filterSelect) return;

    loadCustomDrills(userId, filterSelect.value || "color");

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

    const cfg = DRILL_TYPE_CONFIG[type] || DRILL_TYPE_CONFIG.color;

    try {
        const res = await fetch(cfg.buildListUrl(userId));

        if (!res.ok) {
            emptyMsg.style.display = "block";
            return;
        }

        const drills = await res.json();

        const active = drills.filter(d => {
            const del = d.deletedAt ?? d.DeletedAt;
            return del === null || del === undefined;
        });

        if (!active.length) {
            emptyMsg.style.display = "block";
            return;
        }

        active.sort((a, b) => Number(b.id ?? b.Id ?? 0) - Number(a.id ?? a.Id ?? 0));

        active.forEach(d => {
            const id = d.id ?? d.Id;
            const fullName = d.name ?? d.Name ?? cfg.defaultName;
            const shortName = fullName.length > 18 ? fullName.slice(0, 16) + "…" : fullName;

            const card = document.createElement("div");
            card.className = "drill-box";

            card.innerHTML = `
                <div class="drill-box-header">
                    <div class="drill-box-tools vertical">
                        <button class="icon-small info-btn" title="View drill summary">
                            <i class='bx bx-help-circle'></i>
                        </button>

                        <button class="icon-small edit-btn" title="Edit drill">
                            <i class='bx bx-pencil'></i>
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

            card.querySelector(".start-btn")?.addEventListener("click", () => {
                window.location.href = cfg.buildPlayUrl(id);
            });

            card.querySelector(".info-btn")?.addEventListener("click", () => {
                showDrillSummary(d, cfg.type);
            });

            card.querySelector(".edit-btn")?.addEventListener("click", async (ev) => {
                ev.stopPropagation();
                ev.preventDefault();

                await openEditDrillModal(d, cfg, userId, type);
            });

            card.querySelector(".delete-btn")?.addEventListener("click", async (ev) => {
                ev.stopPropagation();
                ev.preventDefault();

                const ok = await uiConfirm("Are you sure you want to delete this drill?", "Delete Drill");
                if (!ok) return;

                await fetch(cfg.buildDeleteUrl(id), { method: "POST" });
                await loadCustomDrills(userId, type);
            });

            container.appendChild(card);
        });

        requestAnimationFrame(() => applyEllipsisTooltips());

    } catch {
        emptyMsg.style.display = "block";
    }
}

async function openEditDrillModal(drill, cfg, userId, type) {

    const id = drill.id ?? drill.Id;

    const name = drill.name ?? drill.Name ?? "";
    const description = drill.description ?? drill.Description ?? "";
    const totalDurationSec = drill.totalDurationSec ?? drill.TotalDurationSec ?? 0;
    const difficultyLevel = drill.difficultyLevel ?? drill.DifficultyLevel ?? "Easy";

    let dynamicFields = "";

    // COLOR DRILL
    if (type === "color") {

        const selectedIds = (drill.selectedColorIds ?? drill.SelectedColorIds ?? "")
            .split(",")
            .map(x => x.trim())
            .filter(Boolean);

        const actionMap = {};

        (drill.actionsPerColor ?? drill.ActionsPerColor ?? "")
            .split(";")
            .map(x => x.trim())
            .filter(Boolean)
            .forEach(pair => {
                const [colorId, action] = pair.split(":");

                if (colorId) {
                    actionMap[colorId.trim()] = action?.trim() || "";
                }
            });

        dynamicFields = `
        <div class="edit-section-title">Color Actions</div>

        <div class="edit-color-list">
            ${selectedIds.map((colorId, index) => {
            const colorName = COLOR_NAME_MAP[Number(colorId)] || colorId;
            const colorCss = getColorCss(colorName);

            return `
                    <div class="edit-color-action-row">
                        <div class="edit-color-index">${index + 1}</div>

                        <div class="edit-color-name-box">
                            <span class="edit-color-dot" style="background:${colorCss};"></span>
                            <strong>${escapeHtml(colorName)}</strong>
                        </div>

                        <div class="edit-color-action-box">
                            <label>Action</label>
                            <input
                                class="edit-color-action"
                                data-color-id="${escapeHtml(colorId)}"
                                value="${escapeHtml(actionMap[colorId] || "")}"
                                placeholder="Example: Jump"
                            >
                        </div>
                    </div>
                `;
        }).join("")}
        </div>
    `;
    }

    // SOUND DRILL
    else if (type === "sound") {

        const voiceCommandList =
            drill.voiceCommandList ??
            drill.VoiceCommandList ??
            "";

        const commandIntervalSec =
            drill.commandIntervalSec ??
            drill.CommandIntervalSec ??
            1;

        const isRandomOrder =
            drill.isRandomOrder ??
            drill.IsRandomOrder ??
            false;

        const commands = voiceCommandList
            .split(/[;,]/)
            .map(x => x.trim())
            .filter(Boolean);

        dynamicFields = `
        <div class="edit-section-title">Voice Command Setup</div>

        <div class="edit-sound-list" id="editSoundList">
            ${commands.length
                ? commands.map((command, index) => `
                        <div class="edit-sound-row">
                            <div class="edit-sound-index">${index + 1}</div>

                            <div class="edit-sound-name-box">
                                <label>Voice Command</label>
                                <input 
                                    class="edit-sound-command"
                                    value="${escapeHtml(command)}"
                                    placeholder="Example: Jump"
                                >
                            </div>

                            <button 
                                type="button" 
                                class="edit-sound-play"
                                title="Listen command"
                                data-command="${escapeHtml(command)}"
                            >
                                <i class='bx bx-volume-full'></i>
                            </button>
                        </div>
                    `).join("")
                : `
                        <div class="edit-sound-row">
                            <div class="edit-sound-index">1</div>

                            <div class="edit-sound-name-box">
                                <label>Voice Command</label>
                                <input 
                                    class="edit-sound-command"
                                    value=""
                                    placeholder="Example: Jump"
                                >
                            </div>

                            <button 
                                type="button" 
                                class="edit-sound-play"
                                title="Listen command"
                                data-command=""
                            >
                                <i class='bx bx-volume-full'></i>
                            </button>
                        </div>
                    `
            }
        </div>

        <div class="edit-two-col">
            <div>
                <label>Command Interval Sec</label>
                <input id="editCommandInterval"
                       type="number"
                       min="1"
                       value="${commandIntervalSec}">
            </div>

            <div>
                <label>Random Order</label>
                <select id="editSoundRandomOrder">
                    <option value="false" ${!isRandomOrder ? "selected" : ""}>No</option>
                    <option value="true" ${isRandomOrder ? "selected" : ""}>Yes</option>
                </select>
            </div>
        </div>
    `;
    }

    // TEXT DRILL
    else if (type === "text") {

        const exNames =
            drill.exNames ??
            drill.ExNames ??
            "";

        const exDurationsSec =
            drill.exDurationsSec ??
            drill.ExDurationsSec ??
            "";

        const isSequential =
            drill.isSequential ??
            drill.IsSequential ??
            true;

        const hasBreakBtwExs =
            drill.hasBreakBtwExs ??
            drill.HasBreakBtwExs ??
            false;

        const breakBtwExsSec =
            drill.breakBtwExsSec ??
            drill.BreakBtwExsSec ??
            0;

        const repeatCount =
            drill.repeatCount ??
            drill.RepeatCount ??
            1;

        const hasBreakBtwRepeats =
            drill.hasBreakBtwRepeats ??
            drill.HasBreakBtwRepeats ??
            false;

        const breakBtwRepeatsSec =
            drill.breakBtwRepeatsSec ??
            drill.BreakBtwRepeatsSec ??
            0;

        const demonstrationType =
            drill.demonstrationType ??
            drill.DemonstrationType ??
            "text";

        dynamicFields = `
        <div class="edit-section-title">Exercise Setup</div>

        <div class="edit-exercise-list" id="editExerciseList">
    ${exNames
                .split(";")
                .map(x => x.trim())
                .filter(Boolean)
                .map((exercise, index) => {
                    const duration = exDurationsSec
                        .split(";")
                        .map(x => x.trim())
                        .filter(Boolean)[index] || "";

                    return `
                <div class="edit-exercise-row">
                    <div class="edit-exercise-index">${index + 1}</div>

                    <div class="edit-exercise-name-box">
                        <label>Exercise Name</label>
                        <input 
                            class="edit-ex-name"
                            value="${escapeHtml(exercise)}"
                        >
                    </div>

                    <div class="edit-exercise-duration-box">
                        <label>Sec</label>
                        <input 
                            class="edit-ex-duration"
                            type="number"
                            min="1"
                            value="${escapeHtml(duration)}"
                        >
                    </div>
                </div>
            `;
                }).join("")}
</div>

        <div class="edit-two-col">
            <div>
                <label>Exercise Order</label>
                <select id="editIsSequential">
                    <option value="true" ${isSequential ? "selected" : ""}>Sequential</option>
                    <option value="false" ${!isSequential ? "selected" : ""}>Random</option>
                </select>
            </div>

            <div>
                <label>Repeat Count</label>
                <input id="editRepeatCount" type="number" min="1" value="${repeatCount}">
            </div>
        </div>

        <div class="edit-two-col">
            <div>
                <label>Break Between Exercises</label>
                <select id="editHasBreakBtwExs">
                    <option value="false" ${!hasBreakBtwExs ? "selected" : ""}>No</option>
                    <option value="true" ${hasBreakBtwExs ? "selected" : ""}>Yes</option>
                </select>
            </div>

            <div>
                <label>Exercise Break Sec</label>
                <input id="editBreakBtwExsSec" type="number" min="0" value="${breakBtwExsSec}">
            </div>
        </div>

        <div class="edit-two-col">
            <div>
                <label>Break Between Repeats</label>
                <select id="editHasBreakBtwRepeats">
                    <option value="false" ${!hasBreakBtwRepeats ? "selected" : ""}>No</option>
                    <option value="true" ${hasBreakBtwRepeats ? "selected" : ""}>Yes</option>
                </select>
            </div>

            <div>
                <label>Repeat Break Sec</label>
                <input id="editBreakBtwRepeatsSec" type="number" min="0" value="${breakBtwRepeatsSec}">
            </div>
        </div>

        <label>Demonstration Type</label>
        <select id="editDemonstrationType">
            <option value="text" ${demonstrationType === "text" ? "selected" : ""}>Text</option>
            <option value="image" ${demonstrationType === "image" ? "selected" : ""}>Image</option>
            <option value="video" ${demonstrationType === "video" ? "selected" : ""}>Video</option>
        </select>
    `;
    }

    // FOCUS DRILL
    else if (type === "focus") {

        const targetColors =
            drill.targetColors ??
            drill.TargetColors ??
            "";

        const actionsForTargetColors =
            drill.actionsForTargetColors ??
            drill.ActionsForTargetColors ??
            "";

        const switchIntervalSec =
            drill.switchIntervalSec ??
            drill.SwitchIntervalSec ??
            1;

        const targetColorCount =
            drill.targetColorCount ??
            drill.TargetColorCount ??
            0;

        const autoIncreaseDifficulty =
            drill.autoIncreaseDifficulty ??
            drill.AutoIncreaseDifficulty ??
            false;

        const colorList = targetColors
            .split(/[;,]/)
            .map(x => x.trim())
            .filter(Boolean);

        const actionList = actionsForTargetColors
            .split(";")
            .map(x => x.trim())
            .filter(Boolean);

        dynamicFields = `
        <div class="edit-section-title">Focus Target Setup</div>

        <div class="edit-focus-list" id="editFocusList">
            ${colorList.length
                ? colorList.map((color, index) => {
                    const action = actionList[index] || "";

                    return `
                            <div class="edit-focus-row">

                                <div class="edit-focus-color-box">
                                    <label>Target Color</label>

                                    <div class="edit-focus-color-input">
                                        <span style="background:${getColorCss(getColorNameFromValue(color))};"></span>
<input
    class="edit-focus-color"
    value="${escapeHtml(color)}"
    data-color-name="${escapeHtml(getColorNameFromValue(color))}"
    placeholder="Example: 101 or Red"
>
                                    </div>
                                </div>

                                <div class="edit-focus-action-box">
                                    <label>Action</label>
                                    <input
                                        class="edit-focus-action"
                                       value="${escapeHtml(cleanFocusAction(action))}"
                                        placeholder="Example: Punch"
                                    >
                                </div>
                            </div>
                        `;
                }).join("")
                : `
                        <div class="edit-focus-row">
                            <div class="edit-focus-index">1</div>

                            <div class="edit-focus-color-box">
                                <label>Target Color</label>

                                <div class="edit-focus-color-input">
                                    <span style="background:#22c55e;"></span>
                                    <input
                                        class="edit-focus-color"
                                        value=""
                                        placeholder="Example: Green"
                                    >
                                </div>
                            </div>

                            <div class="edit-focus-action-box">
                                <label>Action</label>
                                <input
                                    class="edit-focus-action"
                                    value=""
                                    placeholder="Example: Jump"
                                >
                            </div>
                        </div>
                    `
            }
        </div>

        <div class="edit-two-col">
            <div>
                <label>Switch Interval Sec</label>
                <input id="editFocusSwitchInterval"
                       type="number"
                       min="1"
                       value="${switchIntervalSec}">
            </div>

            <div>
                <label>Target Color Count</label>
                <input id="editFocusTargetColorCount"
                       type="number"
                       min="1"
                       value="${targetColorCount || colorList.length || 1}">
            </div>
        </div>

        <label>Auto Increase Difficulty</label>
        <select id="editFocusAutoIncrease">
            <option value="false" ${!autoIncreaseDifficulty ? "selected" : ""}>No</option>
            <option value="true" ${autoIncreaseDifficulty ? "selected" : ""}>Yes</option>
        </select>
    `;
    }

    // COMB DRILL
    // COMB DRILL
    else if (type === "comb") {

        const commandList =
            drill.commandList ??
            drill.CommandList ??
            "";

        const commandCount =
            drill.commandCount ??
            drill.CommandCount ??
            0;

        const commandsPerCombination =
            drill.commandsPerCombination ??
            drill.CommandsPerCombination ??
            2;

        const combinationDisplaySec =
            drill.combinationDisplaySec ??
            drill.CombinationDisplaySec ??
            2;

        const transitionSec =
            drill.transitionSec ??
            drill.TransitionSec ??
            1;

        const isRandomOrder =
            drill.isRandomOrder ??
            drill.IsRandomOrder ??
            false;

        const allowRepetition =
            drill.allowRepetition ??
            drill.AllowRepetition ??
            false;

        const commands = commandList
            .split(/[;,]/)
            .map(x => x.trim())
            .filter(Boolean);

        dynamicFields = `
        <div class="edit-section-title">Combination Setup</div>

        <div class="edit-comb-list" id="editCombList">
            ${commands.length
                ? commands.map((command) => `
                        <div class="edit-comb-row">
                            <div class="edit-comb-name-box">
                                <label>Command</label>
                                <input 
                                    class="edit-comb-command"
                                    value="${escapeHtml(command)}"
                                    placeholder="Example: Jab"
                                >
                            </div>
                        </div>
                    `).join("")
                : `
                        <div class="edit-comb-row">
                            <div class="edit-comb-name-box">
                                <label>Command</label>
                                <input 
                                    class="edit-comb-command"
                                    value=""
                                    placeholder="Example: Jab"
                                >
                            </div>
                        </div>
                    `
            }
        </div>

        <div class="edit-two-col">
            <div>
                <label>Command Count</label>
                <input id="editCommandCount"
                       type="number"
                       min="1"
                       value="${commandCount || commands.length || 1}">
            </div>

            <div>
                <label>Commands Per Combination</label>
                <input id="editCommandsPerCombination"
                       type="number"
                       min="1"
                       value="${commandsPerCombination}">
            </div>
        </div>

        <div class="edit-two-col">
            <div>
                <label>Combination Display Sec</label>
                <input id="editCombinationDisplaySec"
                       type="number"
                       min="1"
                       value="${combinationDisplaySec}">
            </div>

            <div>
                <label>Transition Sec</label>
                <input id="editTransitionSec"
                       type="number"
                       min="0"
                       value="${transitionSec}">
            </div>
        </div>

        <div class="edit-two-col">
            <div>
                <label>Random Order</label>
                <select id="editCombRandomOrder">
                    <option value="false" ${!isRandomOrder ? "selected" : ""}>No</option>
                    <option value="true" ${isRandomOrder ? "selected" : ""}>Yes</option>
                </select>
            </div>

            <div>
                <label>Allow Repetition</label>
                <select id="editAllowRepetition">
                    <option value="false" ${!allowRepetition ? "selected" : ""}>No</option>
                    <option value="true" ${allowRepetition ? "selected" : ""}>Yes</option>
                </select>
            </div>
        </div>
    `;
    }

    const body = `
        <div class="edit-drill-modal">

            <label>Drill Name</label>
            <input id="editDrillName"
                   value="${escapeHtml(name)}">

            <label>Description</label>
            <input id="editDrillDescription"
                   value="${escapeHtml(description)}">

            <label>Total Duration Sec</label>
            <input id="editTotalDuration"
                   type="number"
                   value="${totalDurationSec}">

            <label>Difficulty</label>

            <select id="editDifficulty">
                <option value="Easy"
                    ${difficultyLevel === "Easy" ? "selected" : ""}>
                    Easy
                </option>

                <option value="Medium"
                    ${difficultyLevel === "Medium" ? "selected" : ""}>
                    Medium
                </option>

                <option value="Hard"
                    ${difficultyLevel === "Hard" ? "selected" : ""}>
                    Hard
                </option>
            </select>

            ${dynamicFields}

        </div>
    `;
    setTimeout(() => {
        document.querySelectorAll(".edit-sound-play").forEach(btn => {
            btn.onclick = () => {
                const row = btn.closest(".edit-sound-row");
                const input = row?.querySelector(".edit-sound-command");
                const text = input?.value.trim();

                if (!text) return;

                const speech = new SpeechSynthesisUtterance(text);
                speech.lang = "en-US";
                speech.rate = 0.95;
                speech.pitch = 1;

                window.speechSynthesis.cancel();
                window.speechSynthesis.speak(speech);
            };
        });
    }, 0);

    const ok = await uiModal({
        title: "Edit Custom Drill",
        body,
        buttons: [
            { text: "Cancel", value: false },
            { text: "Update", value: true, className: "primary" }
        ]
    });
    document.querySelectorAll(".edit-sound-play").forEach(btn => {
        btn.onclick = () => {
            const row = btn.closest(".edit-sound-row");
            const input = row?.querySelector(".edit-sound-command");
            const text = input?.value.trim();

            if (!text) return;

            const speech = new SpeechSynthesisUtterance(text);
            speech.lang = "en-US";
            speech.rate = 0.95;
            speech.pitch = 1;

            window.speechSynthesis.cancel();
            window.speechSynthesis.speak(speech);
        };
    });

    if (!ok) return;

    const updatedName =
        document.getElementById("editDrillName").value.trim();

    const updatedDescription =
        document.getElementById("editDrillDescription").value.trim();

    const updatedDuration =
        Number(document.getElementById("editTotalDuration").value);

    const updatedDifficulty =
        document.getElementById("editDifficulty").value;

    const updatedDrill = {

        ...drill,

        id: id,
        Id: id,

        userId: userId,
        UserId: userId,

        name: updatedName,
        Name: updatedName,

        description: updatedDescription,
        Description: updatedDescription,

        totalDurationSec: updatedDuration,
        TotalDurationSec: updatedDuration,

        difficultyLevel: updatedDifficulty,
        DifficultyLevel: updatedDifficulty,

        updatedAt: new Date().toISOString(),
        UpdatedAt: new Date().toISOString()
    };

    // COLOR
    if (type === "color") {

        const actions = [...document.querySelectorAll(".edit-color-action")]
            .map(input =>
                `${input.dataset.colorId}:${input.value.trim()}`
            )
            .join(";");

        updatedDrill.actionsPerColor = actions;
        updatedDrill.ActionsPerColor = actions;
    }

    // SOUND
    else if (type === "sound") {

        const commands = [...document.querySelectorAll(".edit-sound-command")]
            .map(input => input.value.trim())
            .filter(Boolean)
            .join(",");

        const commandCount = [...document.querySelectorAll(".edit-sound-command")]
            .map(input => input.value.trim())
            .filter(Boolean)
            .length;

        const interval =
            Number(document.getElementById("editCommandInterval").value);

        const isRandomOrder =
            document.getElementById("editSoundRandomOrder").value === "true";

        updatedDrill.voiceCommandList = commands;
        updatedDrill.VoiceCommandList = commands;

        updatedDrill.voiceCommandCount = commandCount;
        updatedDrill.VoiceCommandCount = commandCount;

        updatedDrill.commandIntervalSec = interval;
        updatedDrill.CommandIntervalSec = interval;

        updatedDrill.isRandomOrder = isRandomOrder;
        updatedDrill.IsRandomOrder = isRandomOrder;
    }

    // TEXT
    // TEXT
    else if (type === "text") {

        const exNames = [...document.querySelectorAll(".edit-ex-name")]
            .map(input => input.value.trim())
            .filter(Boolean)
            .join(";");

        const exDurations = [...document.querySelectorAll(".edit-ex-duration")]
            .map(input => input.value.trim())
            .filter(Boolean)
            .join(";");

        const isSequential =
            document.getElementById("editIsSequential").value === "true";

        const hasBreakBtwExs =
            document.getElementById("editHasBreakBtwExs").value === "true";

        const breakBtwExsSec =
            Number(document.getElementById("editBreakBtwExsSec").value);

        const repeatCount =
            Number(document.getElementById("editRepeatCount").value);

        const hasBreakBtwRepeats =
            document.getElementById("editHasBreakBtwRepeats").value === "true";

        const breakBtwRepeatsSec =
            Number(document.getElementById("editBreakBtwRepeatsSec").value);

        const demonstrationType =
            document.getElementById("editDemonstrationType").value;

        updatedDrill.exNames = exNames;
        updatedDrill.ExNames = exNames;

        updatedDrill.exDurationsSec = exDurations;
        updatedDrill.ExDurationsSec = exDurations;

        updatedDrill.isSequential = isSequential;
        updatedDrill.IsSequential = isSequential;

        updatedDrill.hasBreakBtwExs = hasBreakBtwExs;
        updatedDrill.HasBreakBtwExs = hasBreakBtwExs;

        updatedDrill.breakBtwExsSec = breakBtwExsSec;
        updatedDrill.BreakBtwExsSec = breakBtwExsSec;

        updatedDrill.repeatCount = repeatCount;
        updatedDrill.RepeatCount = repeatCount;

        updatedDrill.hasBreakBtwRepeats = hasBreakBtwRepeats;
        updatedDrill.HasBreakBtwRepeats = hasBreakBtwRepeats;

        updatedDrill.breakBtwRepeatsSec = breakBtwRepeatsSec;
        updatedDrill.BreakBtwRepeatsSec = breakBtwRepeatsSec;

        updatedDrill.demonstrationType = demonstrationType;
        updatedDrill.DemonstrationType = demonstrationType;
    }

    // FOCUS
    // FOCUS
    else if (type === "focus") {

        const targetColors = [...document.querySelectorAll(".edit-focus-color")]
            .map(input => input.value.trim())
            .filter(Boolean)
            .join(";");

        const actionsForTargetColors = [...document.querySelectorAll(".edit-focus-action")]
            .map(input => input.value.trim())
            .filter(Boolean)
            .join(";");

        const switchInterval =
            Number(document.getElementById("editFocusSwitchInterval").value);

        const targetColorCount =
            Number(document.getElementById("editFocusTargetColorCount").value);

        const autoIncreaseDifficulty =
            document.getElementById("editFocusAutoIncrease").value === "true";

        updatedDrill.targetColors = targetColors;
        updatedDrill.TargetColors = targetColors;

        updatedDrill.actionsForTargetColors = actionsForTargetColors;
        updatedDrill.ActionsForTargetColors = actionsForTargetColors;

        updatedDrill.switchIntervalSec = switchInterval;
        updatedDrill.SwitchIntervalSec = switchInterval;

        updatedDrill.targetColorCount = targetColorCount;
        updatedDrill.TargetColorCount = targetColorCount;

        updatedDrill.autoIncreaseDifficulty = autoIncreaseDifficulty;
        updatedDrill.AutoIncreaseDifficulty = autoIncreaseDifficulty;
    }

    // COMB
    // COMB
    else if (type === "comb") {

        const commandList = [...document.querySelectorAll(".edit-comb-command")]
            .map(input => input.value.trim())
            .filter(Boolean)
            .join(";");

        const commandCount =
            Number(document.getElementById("editCommandCount").value);

        const commandsPerCombination =
            Number(document.getElementById("editCommandsPerCombination").value);

        const combinationDisplaySec =
            Number(document.getElementById("editCombinationDisplaySec").value);

        const transitionSec =
            Number(document.getElementById("editTransitionSec").value);

        const isRandomOrder =
            document.getElementById("editCombRandomOrder").value === "true";

        const allowRepetition =
            document.getElementById("editAllowRepetition").value === "true";

        updatedDrill.commandList = commandList;
        updatedDrill.CommandList = commandList;

        updatedDrill.commandCount = commandCount;
        updatedDrill.CommandCount = commandCount;

        updatedDrill.commandsPerCombination = commandsPerCombination;
        updatedDrill.CommandsPerCombination = commandsPerCombination;

        updatedDrill.combinationDisplaySec = combinationDisplaySec;
        updatedDrill.CombinationDisplaySec = combinationDisplaySec;

        updatedDrill.transitionSec = transitionSec;
        updatedDrill.TransitionSec = transitionSec;

        updatedDrill.isRandomOrder = isRandomOrder;
        updatedDrill.IsRandomOrder = isRandomOrder;

        updatedDrill.allowRepetition = allowRepetition;
        updatedDrill.AllowRepetition = allowRepetition;
    }

    const res = await fetch(cfg.buildUpdateUrl(), {
        method: "PUT",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(updatedDrill)
    });

    if (!res.ok) {
        await uiAlert("Drill update failed.", "Error");
        return;
    }

    await uiAlert("Drill updated successfully.", "Success");

    await loadCustomDrills(userId, type);
}

function showDrillSummary(drill, type) {
    const cfg = DRILL_TYPE_CONFIG[type] || DRILL_TYPE_CONFIG.color;

    const name = getProp(drill, "name", "Name", cfg.defaultName);
    const desc = getProp(drill, "description", "Description", "-");

    const val = (lower, upper, fallback = "-") =>
        drill?.[lower] ?? drill?.[upper] ?? fallback;

    const boolText = (v) => v ? "Yes" : "No";

    const splitList = (text) =>
        String(text || "")
            .split(/[;,]/)
            .map(x => x.trim())
            .filter(Boolean);

    const infoRow = (label, value, suffix = "") => {
        if (value === "-" || value === "" || value === null || value === undefined) return "";
        return `
            <div class="summary-line">
                <span>${escapeHtml(label)}</span>
                <strong>${escapeHtml(value)}${suffix}</strong>
            </div>
        `;
    };

    const listBlock = (title, items) => {
        if (!items || !items.length) return "";
        return `
            <div class="summary-block">
                <h4>${escapeHtml(title)}</h4>
                <ul>
                    ${items.map(item => `<li>${escapeHtml(item)}</li>`).join("")}
                </ul>
            </div>
        `;
    };

    let details = "";

    if (type === "color") {
        const actions = String(val("actionsPerColor", "ActionsPerColor", ""))
            .split(";")
            .map(x => x.trim())
            .filter(Boolean)
            .map(pair => {
                const [colorIdRaw, actionRaw] = pair.split(":");
                const colorId = String(colorIdRaw || "").replace(/[^\d]/g, "");
                const colorName = COLOR_NAME_MAP[Number(colorId)] || colorIdRaw || "Color";

                return {
                    colorId,
                    colorName,
                    action: actionRaw || "-"
                };
            });

        const total = val("totalDurationSec", "TotalDurationSec");
        const colorCount = val("colorCount", "ColorCount");
        const interval = val("switchIntervalSec", "SwitchIntervalSec");
        const random = boolText(val("isRandomOrder", "IsRandomOrder", false));
        const difficulty = val("difficultyLevel", "DifficultyLevel");

        details = `
        <div class="text-summary-shell">
            <div class="text-summary-grid">
                <div class="text-summary-item">
                    <small>Total Time</small>
                    <b>${escapeHtml(total)} sec</b>
                </div>

                <div class="text-summary-item">
                    <small>Colors</small>
                    <b>${escapeHtml(colorCount)}</b>
                </div>

                <div class="text-summary-item">
                    <small>Interval</small>
                    <b>${escapeHtml(interval)} sec</b>
                </div>

                <div class="text-summary-item">
                    <small>Difficulty</small>
                    <b>${escapeHtml(difficulty)}</b>
                </div>

                <div class="text-summary-item">
                    <small>Random</small>
                    <b>${escapeHtml(random)}</b>
                </div>
            </div>

            <div class="text-command-area">
                <div class="text-command-title">Color Actions</div>

                <div class="color-summary-list">
                    ${actions.length
                ? actions.map((item, index) => `
                                <div class="color-summary-row">
                                    <span class="color-summary-index">${index + 1}</span>

                                    <div class="color-summary-name">
                                        <i style="background:${getColorCss(item.colorName)};"></i>
                                        <strong>${escapeHtml(item.colorName)}</strong>
                                    </div>

                                    <em>${escapeHtml(item.action)}</em>
                                </div>
                            `).join("")
                : `<p class="summary-empty">No color actions found.</p>`
            }
                </div>
            </div>
        </div>
    `;
    }

    else if (type === "text") {
        const exercises = splitList(val("exNames", "ExNames", ""));
        const durations = splitList(val("exDurationsSec", "ExDurationsSec", ""));

        const exerciseItems = exercises.map((ex, i) => ({
            name: ex,
            duration: durations[i] || "-"
        }));

        const total = val("totalDurationSec", "TotalDurationSec");
        const order = val("isSequential", "IsSequential", false) ? "Sequential" : "Random";
        const repeat = val("repeatCount", "RepeatCount", 1);
        const demo = val("demonstrationType", "DemonstrationType", "text");

        details = `
        <div class="text-summary-shell">
            <div class="text-summary-grid">
                <div class="text-summary-item">
                    <small>Total Time</small>
                    <b>${escapeHtml(total)} sec</b>
                </div>

                <div class="text-summary-item">
                    <small>Order</small>
                    <b>${escapeHtml(order)}</b>
                </div>

                <div class="text-summary-item">
                    <small>Repeat</small>
                    <b>${escapeHtml(repeat)}</b>
                </div>

                <div class="text-summary-item">
                    <small>Type</small>
                    <b>${escapeHtml(demo)}</b>
                </div>
            </div>

            <div class="text-command-area">
                <div class="text-command-title">Exercises</div>

                <div class="text-exercise-list">
                    ${exerciseItems.length
                ? exerciseItems.map((item, index) => `
                                <div class="text-exercise-row">
                                    <span>${index + 1}</span>
                                    <strong>${escapeHtml(item.name)}</strong>
                                    <em>${escapeHtml(item.duration)} sec</em>
                                </div>
                            `).join("")
                : `<p class="summary-empty">No exercises found.</p>`
            }
                </div>
            </div>
        </div>
    `;
    }

    else if (type === "sound") {
        const commands = splitList(val("voiceCommandList", "VoiceCommandList", ""));
        const interval = val("commandIntervalSec", "CommandIntervalSec", "-");

        const commandItems = commands.map(command => ({
            name: command,
            duration: interval
        }));

        const total = val("totalDurationSec", "TotalDurationSec");
        const count = val("voiceCommandCount", "VoiceCommandCount", commands.length);
        const random = boolText(val("isRandomOrder", "IsRandomOrder", false));
        const difficulty = val("difficultyLevel", "DifficultyLevel");

        details = `
        <div class="text-summary-shell">
            <div class="text-summary-grid">
                <div class="text-summary-item">
                    <small>Total Time</small>
                    <b>${escapeHtml(total)} sec</b>
                </div>

                <div class="text-summary-item">
                    <small>Commands</small>
                    <b>${escapeHtml(count)}</b>
                </div>

                <div class="text-summary-item">
                    <small>Interval</small>
                    <b>${escapeHtml(interval)} sec</b>
                </div>

                <div class="text-summary-item">
                    <small>Random</small>
                    <b>${escapeHtml(random)}</b>
                </div>

                <div class="text-summary-item">
                    <small>Difficulty</small>
                    <b>${escapeHtml(difficulty)}</b>
                </div>
            </div>

            <div class="text-command-area">
                <div class="text-command-title">Voice Commands</div>

                <div class="sound-summary-list">
                    ${commandItems.length
                ? commandItems.map((item, index) => `
                                <div class="sound-summary-row">
                                    <span>${index + 1}</span>

                                    <strong>${escapeHtml(item.name)}</strong>

                                    <em>${escapeHtml(item.duration)} sec</em>

                                    <button 
                                        type="button" 
                                        class="sound-summary-play"
                                        data-command="${escapeHtml(item.name)}"
                                        title="Listen command"
                                    >
                                        <i class='bx bx-volume-full'></i>
                                    </button>
                                </div>
                            `).join("")
                : `<p class="summary-empty">No voice commands found.</p>`
            }
                </div>
            </div>
        </div>
    `;

        setTimeout(() => {
            document.querySelectorAll(".sound-summary-play").forEach(btn => {
                btn.onclick = () => {
                    const text = btn.dataset.command;

                    if (!text) return;

                    const speech = new SpeechSynthesisUtterance(text);
                    speech.lang = "en-US";
                    speech.rate = 0.95;
                    speech.pitch = 1;

                    window.speechSynthesis.cancel();
                    window.speechSynthesis.speak(speech);
                };
            });
        }, 0);
    }

    else if (type === "comb") {
        const commands = splitList(val("commandList", "CommandList", ""));

        const total = val("totalDurationSec", "TotalDurationSec");
        const commandCount = val("commandCount", "CommandCount", commands.length);
        const commandsPerCombination = val("commandsPerCombination", "CommandsPerCombination");
        const displaySec = val("combinationDisplaySec", "CombinationDisplaySec");
        const transitionSec = val("transitionSec", "TransitionSec");
        const random = boolText(val("isRandomOrder", "IsRandomOrder", false));
        const repetition = boolText(val("allowRepetition", "AllowRepetition", false));
        const difficulty = val("difficultyLevel", "DifficultyLevel");

        details = `
        <div class="text-summary-shell">
            <div class="text-summary-grid">
                <div class="text-summary-item">
                    <small>Total Time</small>
                    <b>${escapeHtml(total)} sec</b>
                </div>

                <div class="text-summary-item">
                    <small>Commands</small>
                    <b>${escapeHtml(commandCount)}</b>
                </div>

                <div class="text-summary-item">
                    <small>Per Combo</small>
                    <b>${escapeHtml(commandsPerCombination)}</b>
                </div>

                <div class="text-summary-item">
                    <small>Display</small>
                    <b>${escapeHtml(displaySec)} sec</b>
                </div>

                <div class="text-summary-item">
                    <small>Transition</small>
                    <b>${escapeHtml(transitionSec)} sec</b>
                </div>

                <div class="text-summary-item">
                    <small>Random</small>
                    <b>${escapeHtml(random)}</b>
                </div>

                <div class="text-summary-item">
                    <small>Repetition</small>
                    <b>${escapeHtml(repetition)}</b>
                </div>

                <div class="text-summary-item">
                    <small>Difficulty</small>
                    <b>${escapeHtml(difficulty)}</b>
                </div>
            </div>

            <div class="text-command-area">
                <div class="text-command-title">Combination Commands</div>

                <div class="comb-summary-list">
                    ${commands.length
                ? commands.map((command) => `
                                <div class="comb-summary-row">
                                    <strong>${escapeHtml(command)}</strong>
                                    <em>${escapeHtml(displaySec)} sec</em>
                                </div>
                            `).join("")
                : `<p class="summary-empty">No commands found.</p>`
            }
                </div>
            </div>
        </div>
    `;
    }

    else if (type === "focus") {
        const targetColors = splitList(val("targetColors", "TargetColors", ""));

        const actions = String(val("actionsForTargetColors", "ActionsForTargetColors", ""))
            .split(";")
            .map(x => x.trim())
            .filter(Boolean);

        const focusItems = targetColors.map((color, index) => {
            const colorName = getColorNameFromValue(color);
            const action = cleanFocusAction(actions[index] || "-");

            return {
                rawColor: color,
                colorName,
                action
            };
        });

        const total = val("totalDurationSec", "TotalDurationSec");
        const interval = val("switchIntervalSec", "SwitchIntervalSec");
        const targetCount = val("targetColorCount", "TargetColorCount", targetColors.length);
        const autoIncrease = boolText(val("autoIncreaseDifficulty", "AutoIncreaseDifficulty", false));
        const difficulty = val("difficultyLevel", "DifficultyLevel");

        details = `
        <div class="text-summary-shell">
            <div class="text-summary-grid">
                <div class="text-summary-item">
                    <small>Total Time</small>
                    <b>${escapeHtml(total)} sec</b>
                </div>

                <div class="text-summary-item">
                    <small>Interval</small>
                    <b>${escapeHtml(interval)} sec</b>
                </div>

                <div class="text-summary-item">
                    <small>Targets</small>
                    <b>${escapeHtml(targetCount)}</b>
                </div>

                <div class="text-summary-item">
                    <small>Difficulty</small>
                    <b>${escapeHtml(difficulty)}</b>
                </div>

                <div class="text-summary-item">
                    <small>Auto Increase</small>
                    <b>${escapeHtml(autoIncrease)}</b>
                </div>
            </div>

            <div class="text-command-area">
                <div class="text-command-title">Focus Targets</div>

                <div class="focus-summary-list clean-focus-list">
                    ${focusItems.length
                ? focusItems.map(item => `
                                <div class="focus-summary-row clean-focus-row">
                                    <div class="focus-summary-color">
                                        <i style="background:${getColorCss(item.colorName)};"></i>
                                        <strong>${escapeHtml(item.colorName)}</strong>
                                    </div>

                                    <em>${escapeHtml(item.action)}</em>
                                </div>
                            `).join("")
                : `<p class="summary-empty">No focus targets found.</p>`
            }
                </div>
            </div>
        </div>
    `;
    }

    const body = `
        <div class="simple-summary">
            <div class="simple-summary-head">
                <h3>${escapeHtml(name)}</h3>
                <p>${escapeHtml(desc)}</p>
            </div>

            ${details}
        </div>
    `;

    uiModal({
        title: "Drill Summary",
        body,
        buttons: [{ text: "Close", value: true, className: "primary" }]
    });
}

function uiModal({ title = "Info", body = "", buttons = [{ text: "OK", value: true, className: "primary" }] }) {
    const modal = document.getElementById("appModal");
    const titleEl = document.getElementById("appModalTitle");
    const bodyEl = document.getElementById("appModalBody");
    const actionsEl = document.getElementById("appModalActions");

    if (!modal || !titleEl || !bodyEl || !actionsEl) {
        return Promise.resolve(true);
    }

    let resolve;
    const p = new Promise(r => (resolve = r));

    const close = (val) => {
        modal.classList.add("hidden");
        modal.setAttribute("aria-hidden", "true");
        document.removeEventListener("keydown", onKey);
        resolve(val);
    };

    const onKey = (e) => {
        if (e.key === "Escape") close(false);
    };

    titleEl.textContent = title;
    bodyEl.innerHTML = body;
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

        h3.classList.toggle("has-ellipsis", hasDots || isVisuallyEllipsized);
    });
}

document.addEventListener("DOMContentLoaded", () => {
    applyEllipsisTooltips();

    window.addEventListener("resize", () => {
        applyEllipsisTooltips();
    });
});

const WEEK_DAYS = ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"];

async function openScheduleModal(currentUser) {
    const userId = currentUser.id ?? currentUser.Id ?? 0;

    if (!userId) {
        await uiAlert("User not found.", "Schedule");
        return;
    }

    const drills = await getAllUserCustomDrills(userId);
    const scheduleKey = `trainingSchedule_user_${userId}`;

    let schedule = [];

    try {
        schedule = JSON.parse(localStorage.getItem(scheduleKey) || "[]");
    } catch {
        schedule = [];
    }

    const drillOptions = drills.length
        ? drills.map(d => `
            <option value="${d.type}|${d.id}|${escapeHtml(d.name)}|${escapeHtml(d.playUrl)}">
                ${escapeHtml(d.name)} (${escapeHtml(d.label)})
            </option>
        `).join("")
        : `<option value="">No custom drills found</option>`;

    const body = `
        <div class="schedule-modal">
            <div class="schedule-form">
                <select id="scheduleDrill">${drillOptions}</select>

                <select id="scheduleDay">
                    ${WEEK_DAYS.map(day => `<option value="${day}">${day}</option>`).join("")}
                </select>

                <input id="scheduleTime" type="time" value="18:00">
                <input id="scheduleDuration" type="number" min="1" value="20" placeholder="Duration minute">

                <button class="start-btn" id="addScheduleBtn">
                    Add To Schedule
                </button>
            </div>

            <div class="schedule-list" id="scheduleList"></div>
        </div>
    `;

    await uiModal({
        title: "Training Schedule",
        body,
        buttons: [{ text: "Close", value: true, className: "primary" }]
    });

    function renderSchedule() {
        const list = document.getElementById("scheduleList");
        if (!list) return;

        list.innerHTML = "";

        WEEK_DAYS.forEach(day => {
            const dayItems = schedule
                .filter(x => x.day === day)
                .sort((a, b) => String(a.time).localeCompare(String(b.time)));

            const box = document.createElement("div");
            box.className = "schedule-day";

            box.innerHTML = `
                <h4>${day}</h4>
                ${dayItems.length
                    ? dayItems.map(item => `
                        <div class="schedule-item">
                            <strong>${escapeHtml(item.drillName)}</strong>
                            <div>${escapeHtml(item.time)} • ${escapeHtml(item.duration)} min</div>
                            <div>${escapeHtml(item.drillLabel)}</div>
                            <button class="schedule-remove" data-id="${item.id}">
                                Remove
                            </button>
                        </div>
                    `).join("")
                    : `<div style="color:#888;font-size:12px;">No training</div>`
                }
            `;

            list.appendChild(box);
        });

        document.querySelectorAll(".schedule-remove").forEach(btn => {
            btn.addEventListener("click", () => {
                const id = Number(btn.dataset.id);
                schedule = schedule.filter(x => x.id !== id);
                localStorage.setItem(scheduleKey, JSON.stringify(schedule));
                renderSchedule();
            });
        });
    }

    setTimeout(() => {
        renderSchedule();

        document.getElementById("addScheduleBtn")?.addEventListener("click", () => {
            const drillValue = document.getElementById("scheduleDrill").value;

            if (!drillValue) {
                uiAlert("Please create a custom drill first.", "Schedule");
                return;
            }

            const [type, drillId, drillName, playUrl] = drillValue.split("|");

            schedule.push({
                id: Date.now(),
                userId,
                type,
                drillId,
                drillName,
                drillLabel: type,
                playUrl,
                day: document.getElementById("scheduleDay").value,
                time: document.getElementById("scheduleTime").value,
                duration: document.getElementById("scheduleDuration").value
            });

            localStorage.setItem(scheduleKey, JSON.stringify(schedule));
            renderSchedule();
        });
    }, 0);
}

async function getAllUserCustomDrills(userId) {
    const result = [];

    for (const key of Object.keys(DRILL_TYPE_CONFIG)) {
        const cfg = DRILL_TYPE_CONFIG[key];

        try {
            const res = await fetch(cfg.buildListUrl(userId));

            if (!res.ok) continue;

            const drills = await res.json();

            drills
                .filter(d => {
                    const deletedAt = d.deletedAt ?? d.DeletedAt;
                    return deletedAt === null || deletedAt === undefined;
                })
                .forEach(d => {
                    const id = d.id ?? d.Id;
                    const name = d.name ?? d.Name ?? cfg.defaultName;

                    result.push({
                        id,
                        name,
                        type: cfg.type,
                        label: cfg.defaultName,
                        playUrl: cfg.buildPlayUrl(id)
                    });
                });

        } catch { }
    }

    return result;
}

let calendarDate = new Date();
let selectedCalendarDate = new Date();

async function openScheduleCalendarModal(currentUser) {
    const userId = currentUser.id ?? currentUser.Id ?? 0;

    if (!userId) {
        await uiAlert("User not found.", "Schedule");
        return;
    }

    const drills = await getAllUserCustomDrills(userId);

    const body = `
        <div class="calendar-modal">

            <div>
                <div class="calendar-header">
                    <button id="prevMonthBtn">‹</button>

                    <div class="calendar-title" id="calendarTitle"></div>

                    <button id="nextMonthBtn">›</button>
                </div>

                <div class="calendar-grid" id="calendarGrid"></div>
            </div>

            <div class="schedule-panel">
                <h3 id="selectedDateTitle">Select a day</h3>

                <label>Custom Drill</label>
                <select id="scheduleDrillSelect">
                    ${drills.length
            ? drills.map(d => `
                            <option value="${d.type}|${d.id}|${escapeHtml(d.name)}">
                                ${escapeHtml(d.name)} (${escapeHtml(d.label)})
                            </option>
                        `).join("")
            : `<option value="">No custom drills found</option>`
        }
                </select>

                <label>Start Time</label>
                <input type="time" id="scheduleStartTime" value="18:00">

                <label>End Time</label>
                <input type="time" id="scheduleEndTime" value="18:30">

                <button class="schedule-add-btn" id="addScheduleBtn">
                    Add Schedule
                </button>

                <div id="selectedDaySchedules"></div>
            </div>

        </div>
    `;

    uiModal({
        title: "Training Schedule",
        body,
        buttons: [
            { text: "Close", value: true, className: "primary" }
        ]
    });

    setTimeout(async () => {
        await renderScheduleCalendar(userId);

        document.getElementById("prevMonthBtn").onclick = async () => {
            calendarDate.setMonth(calendarDate.getMonth() - 1);
            await renderScheduleCalendar(userId);
        };

        document.getElementById("nextMonthBtn").onclick = async () => {
            calendarDate.setMonth(calendarDate.getMonth() + 1);
            await renderScheduleCalendar(userId);
        };

        document.getElementById("addScheduleBtn").onclick = async () => {
            await addScheduleFromModal(userId);
            await renderScheduleCalendar(userId);
        };
    }, 0);
}

async function renderScheduleCalendar(userId) {
    const grid = document.getElementById("calendarGrid");
    const title = document.getElementById("calendarTitle");

    if (!grid || !title) return;

    const schedules = await fetchSchedules(userId);

    const year = calendarDate.getFullYear();
    const month = calendarDate.getMonth();

    title.textContent = calendarDate.toLocaleString("en-US", {
        month: "long",
        year: "numeric"
    });

    grid.innerHTML = "";

    const dayNames = ["M", "T", "W", "T", "F", "S", "S"];

    dayNames.forEach(d => {
        const el = document.createElement("div");
        el.className = "calendar-day-name";
        el.textContent = d;
        grid.appendChild(el);
    });

    const firstDate = new Date(year, month, 1);
    const startOffset = (firstDate.getDay() + 6) % 7;

    const daysInMonth = new Date(year, month + 1, 0).getDate();

    for (let i = 0; i < startOffset; i++) {
        const empty = document.createElement("div");
        empty.className = "calendar-day muted";
        grid.appendChild(empty);
    }

    for (let day = 1; day <= daysInMonth; day++) {
        const dateObj = new Date(year, month, day);
        const dateKey = makeDateKey(dateObj);

        const todayKey = makeDateKey(new Date());
        const selectedKey = makeDateKey(selectedCalendarDate);

        const daySchedules = schedules.filter(x => x.day === dateKey);

        const box = document.createElement("div");
        box.className = "calendar-day";

        if (dateKey === todayKey) box.classList.add("today");
        if (dateKey === selectedKey) box.classList.add("selected");

        box.innerHTML = `
    <div class="day-number">${day}</div>

    ${daySchedules.length
                ? `
            <div class="workout-badge">
                Workout Today
            </div>
            <div class="workout-count">
                ${daySchedules.length} training
            </div>
        `
                : ""
            }
`;

        box.onclick = async () => {
            selectedCalendarDate = dateObj;
            await renderScheduleCalendar(userId);
            renderSelectedDayPanel(schedules, dateKey);
        };

        grid.appendChild(box);
    }

    renderSelectedDayPanel(schedules, makeDateKey(selectedCalendarDate));
}

function renderSelectedDayPanel(schedules, dateKey) {
    const title = document.getElementById("selectedDateTitle");
    const list = document.getElementById("selectedDaySchedules");

    if (!title || !list) return;

    const selectedDate = new Date(dateKey);

    title.textContent = selectedDate.toLocaleDateString("en-US", {
        weekday: "long",
        month: "long",
        day: "numeric"
    });

    const items = schedules
        .filter(x => x.day === dateKey || x.Day === dateKey)
        .sort((a, b) => String(a.startTime ?? a.StartTime).localeCompare(String(b.startTime ?? b.StartTime)));

    if (!items.length) {
        list.innerHTML = `
            <div class="selected-empty">
                No workout planned for this day.
            </div>
        `;
        return;
    }

    list.innerHTML = `
        <div class="today-plan-title">What will you do today?</div>

        ${items.map(s => {
        const id = s.id ?? s.Id;
        const drillName = s.drillName ?? s.DrillName;
        const drillType = s.drillType ?? s.DrillType;
        const start = s.startTime ?? s.StartTime;
        const end = s.endTime ?? s.EndTime;

        return `
                <div class="today-workout-card">
                    <div>
                        <strong>${escapeHtml(drillName)}</strong>
                        <span>${formatTime(start)} - ${formatTime(end)}</span>
                        <small>${escapeHtml(drillType)}</small>
                    </div>

                    <button class="mini-delete-btn" onclick="deleteSchedule(${id})">
                        ×
                    </button>
                </div>
            `;
    }).join("")}
    `;
}

async function addScheduleFromModal(userId) {
    const drillValue = document.getElementById("scheduleDrillSelect").value;
    const startTime = document.getElementById("scheduleStartTime").value;
    const endTime = document.getElementById("scheduleEndTime").value;

    if (!drillValue) {
        await uiAlert("Please create a custom drill first.", "Schedule");
        return;
    }

    if (!startTime || !endTime || endTime <= startTime) {
        await uiAlert("End time must be greater than start time.", "Schedule");
        return;
    }

    const [drillType, drillId, drillName] = drillValue.split("|");
    const selectedDay = makeDateKey(selectedCalendarDate);

    const schedule = {
        userId: userId,
        drillType: drillType,
        drillId: Number(drillId),
        drillName: drillName,
        day: selectedDay,
        startTime: startTime + ":00",
        endTime: endTime + ":00"
    };

    await fetch("/api/Schedule/Add", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(schedule)
    });

    const schedules = await fetchSchedules(userId);
    renderSelectedDayPanel(schedules, selectedDay);
}

async function fetchSchedules(userId) {
    try {
        const res = await fetch(`/api/Schedule/GetByUser?userId=${userId}`);

        if (!res.ok) return [];

        return await res.json();
    } catch {
        return [];
    }
}

async function deleteSchedule(id) {
    const ok = await uiConfirm("Delete this schedule?", "Delete Schedule");

    if (!ok) return;

    await fetch(`/api/Schedule/SoftDelete?id=${id}`, {
        method: "POST"
    });

    const stored = JSON.parse(localStorage.getItem("currentUser"));
    const userId = stored.id ?? stored.Id;

    await renderScheduleCalendar(userId);
}

function makeDateKey(date) {
    const y = date.getFullYear();
    const m = String(date.getMonth() + 1).padStart(2, "0");
    const d = String(date.getDate()).padStart(2, "0");

    return `${y}-${m}-${d}`;
}

function formatTime(value) {
    if (!value) return "";

    return String(value).substring(0, 5);
}
function getColorCss(colorName = "") {
    const map = {
        Red: "#ef4444",
        Blue: "#2563eb",
        Green: "#22c55e",
        Yellow: "#facc15",
        Orange: "#f97316",
        Purple: "#a855f7",
        Pink: "#f9a8d4",
        Turquoise: "#2dd4bf",
        Navy: "#1e3a8a",
        SkyBlue: "#7dd3fc",
        RoyalBlue: "#2563eb",
        MidnightBlue: "#172554",
        Emerald: "#10b981",
        Mint: "#86efac",
        ForestGreen: "#166534",
        Olive: "#84cc16",
        Lavender: "#c4b5fd",
        Magenta: "#d946ef",
        Amethyst: "#9333ea",
        Orchid: "#e879f9",
        Salmon: "#fb7185",
        Coral: "#fb923c",
        Peach: "#fdba74",
        Apricot: "#fed7aa",
        Gold: "#facc15",
        Amber: "#f59e0b",
        Mustard: "#ca8a04",
        HoneyYellow: "#fde047",
        Silver: "#d1d5db",
        Titanium: "#9ca3af",
        SlateGray: "#64748b",
        LightGray: "#e5e7eb"
    };

    return map[colorName] || String(colorName).toLowerCase();
}
function getColorNameFromValue(value = "") {
    const clean = String(value).trim();
    const numeric = clean.replace(/[^\d]/g, "");
    return COLOR_NAME_MAP[Number(numeric)] || clean;
}

function cleanFocusAction(action = "") {
    return String(action)
        .replace(/^\s*\d+\s*:\s*/, "")
        .trim();
}