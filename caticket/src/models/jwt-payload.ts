export type JwtPayload = {
  sub: string;
  email: string;
  jti: string;
  nbf: number;
  iat: string;
  role?: string;
  exp: number;
  iss: string;
  aud: string;
};
