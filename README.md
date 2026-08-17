# ticketing-docs

The partner documentation at [docs.ktckts.com](https://docs.ktckts.com), built with
[Astro Starlight](https://starlight.astro.build).

Pages live in `src/content/docs`. Anything in `public/` is served as-is, which is
where the datafeed sample JSON files sit.

## Running it

```bash
pnpm install
pnpm dev
```

`pnpm build` writes the site to `dist/`, and `pnpm preview` serves that build.

## Deploying

Cloudflare Workers Builds builds and deploys every push to `main`. The build
command lives in the Cloudflare dashboard, not in this repository, so a change
of toolchain here needs the command changed there to match.

`wrangler.toml` points Cloudflare at `dist/` and holds the `docs.ktckts.com`
custom domain.
