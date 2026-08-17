import { defineConfig } from "astro/config";
import starlight from "@astrojs/starlight";

export default defineConfig({
	site: "https://docs.ktckts.com",
	integrations: [
		starlight({
			title: "Kaizen Ticketing",
			description: "Guides for partners who integrate with the Kaizen Ticketing platform.",
			customCss: ["./src/styles/custom.css"],
			head: [
				{ tag: "link", attrs: { rel: "preconnect", href: "https://fonts.googleapis.com" } },
				{ tag: "link", attrs: { rel: "preconnect", href: "https://fonts.gstatic.com", crossorigin: true } },
				{
					tag: "link",
					attrs: {
						rel: "stylesheet",
						href: "https://fonts.googleapis.com/css2?family=Manrope:wght@400;600;700;800&display=swap",
					},
				},
			],
			sidebar: [
				{ label: "Datafeeds", link: "/datafeeds/" },
				{ label: "Scheduled Exports", link: "/scheduled-exports/" },
			],
		}),
	],
});
