(function () {
    document.querySelectorAll("[data-nav-toggle]").forEach(btn =>
        btn.addEventListener("click", () => document.body.classList.toggle("nav-open")));

    document.querySelectorAll(".toast-r").forEach(toast => {
        const hide = () => { toast.classList.add("hide"); setTimeout(() => toast.remove(), 300); };
        toast.querySelector("button")?.addEventListener("click", hide);
        setTimeout(hide, 4500);
    });

    document.querySelectorAll("form[data-confirm]").forEach(form =>
        form.addEventListener("submit", e => { if (!confirm(form.dataset.confirm)) e.preventDefault(); }));

    document.querySelectorAll("[data-search]").forEach(input => {
        const target = document.querySelector(input.dataset.search);
        if (!target) return;
        input.addEventListener("input", () => {
            const q = input.value.trim().toLowerCase();
            target.querySelectorAll("[data-search-item]").forEach(item =>
                item.classList.toggle("hidden", !item.textContent.toLowerCase().includes(q)));
        });
    });

    document.querySelectorAll("[data-tabs]").forEach(tabs => {
        const target = document.querySelector(tabs.dataset.tabs);
        tabs.querySelectorAll("button").forEach(btn => btn.addEventListener("click", () => {
            tabs.querySelectorAll("button").forEach(b => b.classList.toggle("active", b === btn));
            const f = btn.dataset.filter;
            target.querySelectorAll("[data-status]").forEach(item =>
                item.classList.toggle("hidden", f !== "All" && item.dataset.status !== f));
        }));
    });

    document.querySelectorAll("[data-photo-input]").forEach(input => {
        const preview = document.querySelector(input.dataset.photoInput);
        input.addEventListener("change", () => {
            const file = input.files && input.files[0];
            if (!file || !preview) return;
            const img = document.createElement("img");
            img.className = preview.className;
            img.alt = "Selected photo";
            img.src = URL.createObjectURL(file);
            preview.replaceWith(img);
        });
    });
})();
