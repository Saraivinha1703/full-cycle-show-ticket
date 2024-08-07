/** @type {import('next').NextConfig} */
const BASE_API_URL = process.env.BASE_SALESAPI_URL ?? "http://localhost:5002";

const nextConfig = {
  async rewrites() {
    return [
      {
        source: "/events",
        destination: `${BASE_API_URL}/events`,
      },
    ];
  },
};

export default nextConfig;
