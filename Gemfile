source "https://rubygems.org"

# This pulls in the same versions of Jekyll and the whitelisted plugins that GitHub Pages uses
gem "github-pages", group: :jekyll_plugins

# Explicitly include this because Just the Docs is a remote theme
gem "jekyll-remote-theme"

# -----------------------------------------------------------------
# Cloudflare Pages / Ruby 3.4 Compatibility Fixes
# -----------------------------------------------------------------
# These libraries were removed from the default Ruby installation in v3.0+
# but are still required by the older Jekyll version used by GitHub Pages.
gem "webrick"
gem "base64"
gem "csv"
gem "logger"
gem "mutex_m"
gem "bigdecimal"
gem "observer"
gem "activesupport", "~> 7.2.3" 
gem "minitest", "~> 5.0"